using System;
using System.Windows.Forms;
using CafeFinance.Models;
using CafeFinance.Services;

namespace CafeFinance.UI
{
    /// <summary>Диалог оформления и редактирования продажи (кассового чека).</summary>
    public partial class SaleForm : Form, IOperationEditor
    {
        private readonly CafeData data;
        private readonly SaleOperation sale = new SaleOperation();

        public SaleForm(CafeData data) : this(data, null)
        {
        }

        public SaleForm(CafeData data, SaleOperation existing)
        {
            InitializeComponent();
            this.data = data;
            FillLists();
            if (existing != null)
            {
                LoadOperation(existing);
            }
            RefreshLines();
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

            cmbPayment.DataSource = Localizer.Items<PaymentMethod>();
            cmbPayment.DisplayMember = "Text";

            cmbDish.DataSource = data.Dishes.ToList();
            cmbDish.DisplayMember = "Name";

            dtpDate.Value = DateTime.Now;
        }

        private void LoadOperation(SaleOperation existing)
        {
            Text = "Продажа №" + existing.Id + " (редактирование)";
            dtpDate.Value = existing.Date;
            cmbEmployee.Text = existing.Employee.Name;
            UiHelper.SelectEnum(cmbPayment, existing.Payment);
            numDiscount.Value = existing.DiscountPercent;
            txtComment.Text = existing.Comment;
            foreach (OrderLine line in existing.Lines)
            {
                sale.AddLine(line.Clone());
            }
        }

        private void RefreshLines()
        {
            dgvLines.Rows.Clear();
            foreach (OrderLine line in sale.Lines)
            {
                int index = dgvLines.Rows.Add(line.Name, line.UnitPrice.ToString("N2"),
                    line.Quantity, line.GetTotal().ToString("N2"));
                dgvLines.Rows[index].Tag = line;
            }
            UpdateTotals();
        }

        private void UpdateTotals()
        {
            sale.DiscountPercent = numDiscount.Value;
            lblSubtotal.Text = "Сумма без скидки: " + sale.GetSubtotal().ToString("N2") + " руб.";
            lblTotal.Text = "Итого к оплате: " + sale.GetAmount().ToString("N2") + " руб.";
        }

        private void numDiscount_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            Dish dish = cmbDish.SelectedItem as Dish;
            if (dish == null)
            {
                UiHelper.ShowError("Следует выбрать блюдо из меню. Меню можно заполнить в разделе «Справочники».");
                return;
            }
            sale.AddLine(new OrderLine(dish, (int)numQuantity.Value));
            numQuantity.Value = 1;
            RefreshLines();
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (dgvLines.CurrentRow == null)
            {
                UiHelper.ShowInfo("Следует выбрать строку чека.");
                return;
            }
            OrderLine line = dgvLines.CurrentRow.Tag as OrderLine;
            if (line != null)
            {
                sale.RemoveLine(line);
                RefreshLines();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Validator.RequireText(cmbEmployee.Text, "Сотрудник", 100);
                sale.Date = dtpDate.Value;
                sale.Employee = data.FindOrCreateEmployee(cmbEmployee.Text);
                sale.Payment = ((EnumItem<PaymentMethod>)cmbPayment.SelectedItem).Value;
                sale.DiscountPercent = numDiscount.Value;
                sale.Comment = txtComment.Text;
                sale.Validate();

                data.RegisterEmployee(sale.Employee);
                Result = sale;
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }
    }
}
