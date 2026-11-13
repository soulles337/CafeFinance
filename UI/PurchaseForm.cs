using System;
using System.Windows.Forms;
using CafeFinance.Models;
using CafeFinance.Services;

namespace CafeFinance.UI
{
    /// <summary>Диалог оформления и редактирования закупки у поставщика.</summary>
    public partial class PurchaseForm : Form, IOperationEditor
    {
        private readonly CafeData data;
        private readonly PurchaseOperation purchase = new PurchaseOperation();

        public PurchaseForm(CafeData data) : this(data, null)
        {
        }

        public PurchaseForm(CafeData data, PurchaseOperation existing)
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
            foreach (Supplier supplier in data.Suppliers)
            {
                cmbSupplier.Items.Add(supplier.Name);
            }
            if (cmbEmployee.Items.Count > 0)
            {
                cmbEmployee.SelectedIndex = 0;
            }
            dtpDate.Value = DateTime.Now;
        }

        private void LoadOperation(PurchaseOperation existing)
        {
            Text = "Закупка №" + existing.Id + " (редактирование)";
            dtpDate.Value = existing.Date;
            cmbEmployee.Text = existing.Employee.Name;
            cmbSupplier.Text = existing.Supplier.Name;
            txtInvoice.Text = existing.InvoiceNumber;
            txtComment.Text = existing.Comment;
            foreach (PurchaseLine line in existing.Lines)
            {
                purchase.AddLine(new PurchaseLine(line.Name, line.Unit, line.Quantity, line.UnitPrice));
            }
        }

        private void RefreshLines()
        {
            dgvLines.Rows.Clear();
            foreach (PurchaseLine line in purchase.Lines)
            {
                int index = dgvLines.Rows.Add(line.Name, line.Unit, line.Quantity,
                    line.UnitPrice.ToString("N2"), line.GetTotal().ToString("N2"));
                dgvLines.Rows[index].Tag = line;
            }
            lblTotal.Text = "Итого по накладной: " + purchase.GetAmount().ToString("N2") + " руб.";
        }

        private void btnAddLine_Click(object sender, EventArgs e)
        {
            try
            {
                string product = Validator.RequireText(txtProduct.Text, "Товар", 100);
                purchase.AddLine(new PurchaseLine(product, txtUnit.Text, numQuantity.Value, numPrice.Value));
                txtProduct.Clear();
                numQuantity.Value = 1;
                numPrice.Value = 0;
                RefreshLines();
                txtProduct.Focus();
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }

        private void btnRemoveLine_Click(object sender, EventArgs e)
        {
            if (dgvLines.CurrentRow == null)
            {
                UiHelper.ShowInfo("Следует выбрать строку накладной.");
                return;
            }
            PurchaseLine line = dgvLines.CurrentRow.Tag as PurchaseLine;
            if (line != null)
            {
                purchase.RemoveLine(line);
                RefreshLines();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Validator.RequireText(cmbEmployee.Text, "Сотрудник", 100);
                Validator.RequireText(cmbSupplier.Text, "Поставщик", 100);
                purchase.Date = dtpDate.Value;
                purchase.Employee = data.FindOrCreateEmployee(cmbEmployee.Text);
                purchase.Supplier = data.FindOrCreateSupplier(cmbSupplier.Text);
                purchase.InvoiceNumber = txtInvoice.Text;
                purchase.Comment = txtComment.Text;
                purchase.Validate();

                data.RegisterEmployee(purchase.Employee);
                data.RegisterSupplier(purchase.Supplier);
                Result = purchase;
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                UiHelper.ShowError(ex.Message);
            }
        }
    }
}
