using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using CafeFinance.Models;
using CafeFinance.Services;
using CafeFinance.Storage;

namespace CafeFinance.UI
{
    /// <summary>Главная форма: журнал операций, поиск, сортировка, итоги и работа с файлом данных.</summary>
    public partial class MainForm : Form
    {
        private const string FileFilter = "Файлы данных кафе (*.cfe)|*.cfe|Все файлы (*.*)|*.*";

        private CafeData data;
        private string filePath;
        private bool modified;
        private bool initializing = true;
        private List<FinancialOperation> shownOperations = new List<FinancialOperation>();

        public MainForm()
        {
            InitializeComponent();
            InitializeFilters();
            initializing = false;
            AttachData(new CafeData(), null);
        }

        // ---------------------------------------------------------------- подготовка

        private void InitializeFilters()
        {
            List<EnumItem<OperationKind?>> kinds = new List<EnumItem<OperationKind?>>
            {
                new EnumItem<OperationKind?>(null, "Все операции"),
                new EnumItem<OperationKind?>(OperationKind.Income, "Доходы"),
                new EnumItem<OperationKind?>(OperationKind.Expense, "Расходы")
            };
            cmbKind.DataSource = kinds;
            cmbKind.DisplayMember = "Text";

            cmbSort.DataSource = Localizer.Items<SortField>();
            cmbSort.DisplayMember = "Text";
        }

        /// <summary>Подключает набор данных к форме и подписывается на его события.</summary>
        private void AttachData(CafeData newData, string path)
        {
            if (data != null)
            {
                data.Journal.Changed -= DataChanged;
                data.Dishes.Changed -= DataChanged;
                data.Employees.Changed -= DataChanged;
                data.Suppliers.Changed -= DataChanged;
            }

            data = newData;
            filePath = path;
            modified = false;

            data.Journal.Changed += DataChanged;
            data.Dishes.Changed += DataChanged;
            data.Employees.Changed += DataChanged;
            data.Suppliers.Changed += DataChanged;

            ApplyFilters();
            UpdateTitle();
        }

        private void DataChanged(object sender, EventArgs e)
        {
            modified = true;
            ApplyFilters();
            UpdateTitle();
        }

        // ---------------------------------------------------------------- отображение

        private void UpdateTitle()
        {
            string name = filePath == null ? "файл не выбран" : Path.GetFileName(filePath);
            Text = "Кафе ПолесГУ — финансовый учёт — " + name + (modified ? " *" : string.Empty);
            lblStatus.Text = filePath == null ? "Файл данных не открыт" : "Файл: " + filePath;
        }

        private void SetStatus(string message)
        {
            lblStatus.Text = message;
        }

        private void ApplyFilters()
        {
            try
            {
                SearchCriteria criteria = ReadCriteria();
                List<FinancialOperation> found = OperationSearcher.Find(data.Journal, criteria);
                SortField field = ((EnumItem<SortField>)cmbSort.SelectedItem).Value;
                shownOperations = OperationSorter.Sort(found, field, chkDescending.Checked);
                FillGrid(shownOperations);
                UpdateSummary(shownOperations);
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }

        private SearchCriteria ReadCriteria()
        {
            SearchCriteria criteria = new SearchCriteria();
            criteria.Text = txtSearch.Text;
            criteria.Kind = ((EnumItem<OperationKind?>)cmbKind.SelectedItem).Value;
            criteria.DateFrom = dtpFrom.Checked ? (DateTime?)dtpFrom.Value : null;
            criteria.DateTo = dtpTo.Checked ? (DateTime?)dtpTo.Value : null;
            criteria.AmountFrom = ParseOptionalAmount(txtAmountFrom.Text, "Сумма от");
            criteria.AmountTo = ParseOptionalAmount(txtAmountTo.Text, "Сумма до");
            return criteria;
        }

        private static decimal? ParseOptionalAmount(string text, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return null;
            }
            return Validator.ParseUserDecimal(text, fieldName);
        }

        private void FillGrid(List<FinancialOperation> operations)
        {
            dgvOperations.Rows.Clear();
            foreach (FinancialOperation operation in operations)
            {
                int index = dgvOperations.Rows.Add(
                    operation.Id,
                    operation.Date.ToString("dd.MM.yyyy HH:mm"),
                    operation.TypeName,
                    operation.Employee.Name,
                    operation.GetDescription(),
                    operation.GetSignedAmount().ToString("N2"));
                DataGridViewRow row = dgvOperations.Rows[index];
                row.Tag = operation;
                if (operation.Kind == OperationKind.Expense)
                {
                    row.DefaultCellStyle.ForeColor = Color.Firebrick;
                }
            }
        }

        private void UpdateSummary(List<FinancialOperation> operations)
        {
            lblIncome.Text = "Доходы: " + FinancialCalculator.TotalIncome(operations).ToString("N2") + " руб.";
            lblExpense.Text = "Расходы: " + FinancialCalculator.TotalExpense(operations).ToString("N2") + " руб.";
            lblProfit.Text = "Прибыль: " + FinancialCalculator.Profit(operations).ToString("N2") + " руб.";
            lblProfitability.Text = "Рентабельность: " + FinancialCalculator.Profitability(operations).ToString("N2") + " %";
        }

        private FinancialOperation GetSelectedOperation()
        {
            if (dgvOperations.CurrentRow == null)
            {
                return null;
            }
            return dgvOperations.CurrentRow.Tag as FinancialOperation;
        }

        // ---------------------------------------------------------------- поиск и сортировка

        private void btnFind_Click(object sender, EventArgs e)
        {
            ApplyFilters();
            SetStatus("Найдено операций: " + shownOperations.Count);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            initializing = true;
            txtSearch.Clear();
            txtAmountFrom.Clear();
            txtAmountTo.Clear();
            dtpFrom.Checked = false;
            dtpTo.Checked = false;
            cmbKind.SelectedIndex = 0;
            initializing = false;
            ApplyFilters();
        }

        private void Sorting_Changed(object sender, EventArgs e)
        {
            if (!initializing && data != null)
            {
                ApplyFilters();
            }
        }

        // ---------------------------------------------------------------- операции

        private void btnAddSale_Click(object sender, EventArgs e)
        {
            RunEditor(new SaleForm(data), null);
        }

        private void btnAddPurchase_Click(object sender, EventArgs e)
        {
            RunEditor(new PurchaseForm(data), null);
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            RunEditor(new ExpenseForm(data), null);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelected();
        }

        private void dgvOperations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditSelected();
            }
        }

        private void EditSelected()
        {
            FinancialOperation selected = GetSelectedOperation();
            if (selected == null)
            {
                UiHelper.ShowInfo("Следует выбрать операцию в таблице.");
                return;
            }
            RunEditor(EditorFactory.CreateFor(data, selected), selected);
        }

        /// <summary>Показывает диалог ввода и помещает результат в журнал (добавление или замена).</summary>
        private void RunEditor(IOperationEditor editor, FinancialOperation existing)
        {
            using (editor)
            {
                if (editor.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                try
                {
                    if (existing == null)
                    {
                        data.Journal.Add(editor.Result);
                        SetStatus("Операция добавлена в журнал.");
                    }
                    else
                    {
                        data.Journal.Replace(existing, editor.Result);
                        SetStatus("Операция изменена.");
                    }
                }
                catch (ValidationException ex)
                {
                    UiHelper.ShowError(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FinancialOperation selected = GetSelectedOperation();
            if (selected == null)
            {
                UiHelper.ShowInfo("Следует выбрать операцию в таблице.");
                return;
            }
            if (!UiHelper.Confirm("Вы действительно хотите удалить операцию «" + selected + "»?"))
            {
                return;
            }
            data.Journal.Remove(selected);
            SetStatus("Операция удалена.");
        }

        // ---------------------------------------------------------------- справочники и отчёты

        private void menuDishes_Click(object sender, EventArgs e)
        {
            using (DishCatalogForm form = new DishCatalogForm(data))
            {
                form.ShowDialog(this);
            }
        }

        private void menuReport_Click(object sender, EventArgs e)
        {
            using (ReportForm form = new ReportForm(data))
            {
                form.ShowDialog(this);
            }
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            UiHelper.ShowInfo("Объектная модель финансовых процессов кафе ПолесГУ.\n" +
                              "Курсовой проект по дисциплине «Объектно-ориентированное проектирование и программирование».");
        }

        // ---------------------------------------------------------------- работа с файлом

        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges())
            {
                return;
            }
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = FileFilter;
                dialog.Title = "Создание файла данных";
                dialog.OverwritePrompt = false;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                try
                {
                    CafeData newData = CafeData.CreateDefault();
                    CafeDataFile.Create(dialog.FileName, newData);
                    AttachData(newData, dialog.FileName);
                    SetStatus("Файл данных создан: " + dialog.FileName);
                }
                catch (DataFileException ex)
                {
                    UiHelper.ShowError(ex.Message);
                }
            }
        }

        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges())
            {
                return;
            }
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = FileFilter;
                dialog.Title = "Открытие файла данных";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                try
                {
                    AttachData(CafeDataFile.Load(dialog.FileName), dialog.FileName);
                    SetStatus("Файл данных загружен: " + dialog.FileName);
                }
                catch (DataFileException ex)
                {
                    UiHelper.ShowError(ex.Message);
                }
            }
        }

        private void menuFileSave_Click(object sender, EventArgs e)
        {
            SaveCurrent();
        }

        private void menuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private void menuFileDelete_Click(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                UiHelper.ShowInfo("Файл данных не открыт.");
                return;
            }
            if (!UiHelper.Confirm("Вы действительно хотите удалить файл «" + Path.GetFileName(filePath) + "»?"))
            {
                return;
            }
            try
            {
                CafeDataFile.Delete(filePath);
                AttachData(new CafeData(), null);
                SetStatus("Файл данных удалён.");
            }
            catch (DataFileException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }

        private void menuFileDemo_Click(object sender, EventArgs e)
        {
            if (!ConfirmDiscardChanges())
            {
                return;
            }
            AttachData(CafeData.CreateDemo(), null);
            modified = true;
            UpdateTitle();
            SetStatus("Загружены демонстрационные данные. Для сохранения следует выбрать «Сохранить как…».");
        }

        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmDiscardChanges())
            {
                e.Cancel = true;
            }
        }

        /// <summary>Предлагает сохранить изменения. Возвращает false, если пользователь отказался продолжать.</summary>
        private bool ConfirmDiscardChanges()
        {
            if (!modified)
            {
                return true;
            }
            DialogResult answer = MessageBox.Show("Есть несохранённые изменения. Сохранить их?",
                UiHelper.Caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (answer == DialogResult.Cancel)
            {
                return false;
            }
            return answer == DialogResult.No || SaveCurrent();
        }

        private bool SaveCurrent()
        {
            return filePath == null ? SaveAs() : SaveTo(filePath);
        }

        private bool SaveAs()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = FileFilter;
                dialog.Title = "Сохранение файла данных";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return false;
                }
                return SaveTo(dialog.FileName);
            }
        }

        private bool SaveTo(string path)
        {
            try
            {
                CafeDataFile.Save(path, data);
                filePath = path;
                modified = false;
                UpdateTitle();
                SetStatus("Файл сохранён: " + path);
                return true;
            }
            catch (DataFileException ex)
            {
                UiHelper.ShowError(ex.Message);
                return false;
            }
        }
    }
}
