using System;
using System.Windows.Forms;
using CafeFinance.Models;
using CafeFinance.Services;

namespace CafeFinance.UI
{
    /// <summary>Диалог ввода и редактирования прочего расхода (аренда, зарплата и др.).</summary>
    public partial class ExpenseForm : Form, IOperationEditor
    {
        private readonly CafeData data;

        public ExpenseForm(CafeData data) : this(data, null)
        {
        }

        public ExpenseForm(CafeData data, ExpenseOperation existing)
        {
            InitializeComponent();
            this.data = data;
            FillLists();
            if (existing != null)
            {
                LoadOperation(existing);
            }
        }

        public FinancialOperation Result { get; private set; }

        private void FillLists()
        {
            foreach (Employee employee in data.Employees)
            {
                cmbEmployee.Items.Add(employee.Name);
            }
            if (cmbEmployee.Items.Count > 0)
            {
                cmbEmployee.SelectedIndex = 0;
            }
            cmbCategory.DataSource = Localizer.Items<ExpenseCategory>();
            cmbCategory.DisplayMember = "Text";
            dtpDate.Value = DateTime.Now;
        }

        private void LoadOperation(ExpenseOperation existing)
        {
            Text = "Расход №" + existing.Id + " (редактирование)";
            dtpDate.Value = existing.Date;
            cmbEmployee.Text = existing.Employee.Name;
            UiHelper.SelectEnum(cmbCategory, existing.Category);
            numAmount.Value = existing.Amount;
            txtComment.Text = existing.Comment;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Validator.RequireText(cmbEmployee.Text, "Сотрудник", 100);
                ExpenseOperation expense = new ExpenseOperation();
                expense.Date = dtpDate.Value;
                expense.Employee = data.FindOrCreateEmployee(cmbEmployee.Text);
                expense.Category = ((EnumItem<ExpenseCategory>)cmbCategory.SelectedItem).Value;
                expense.Amount = numAmount.Value;
                expense.Comment = txtComment.Text;
                expense.Validate();

                data.RegisterEmployee(expense.Employee);
                Result = expense;
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }
    }
}
