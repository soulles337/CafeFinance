namespace CafeFinance.UI
{
    partial class PurchaseForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblDate = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.cmbEmployee = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.txtInvoice = new System.Windows.Forms.TextBox();
            this.grpLines = new System.Windows.Forms.GroupBox();
            this.lblProduct = new System.Windows.Forms.Label();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.lblUnit = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveLine = new System.Windows.Forms.Button();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.grpLines.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(16, 20);
            this.lblDate.Name = "lblDate";
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Дата и время:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(110, 16);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(190, 23);
            this.dtpDate.TabIndex = 1;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Location = new System.Drawing.Point(330, 20);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.TabIndex = 2;
            this.lblEmployee.Text = "Сотрудник:";
            // 
            // cmbEmployee
            // 
            this.cmbEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbEmployee.FormattingEnabled = true;
            this.cmbEmployee.Location = new System.Drawing.Point(410, 16);
            this.cmbEmployee.Name = "cmbEmployee";
            this.cmbEmployee.Size = new System.Drawing.Size(220, 23);
            this.cmbEmployee.TabIndex = 3;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(16, 54);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.TabIndex = 4;
            this.lblSupplier.Text = "Поставщик:";
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(110, 50);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(190, 23);
            this.cmbSupplier.TabIndex = 5;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.Location = new System.Drawing.Point(330, 54);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.TabIndex = 6;
            this.lblInvoice.Text = "Накладная №:";
            // 
            // txtInvoice
            // 
            this.txtInvoice.Location = new System.Drawing.Point(410, 50);
            this.txtInvoice.Name = "txtInvoice";
            this.txtInvoice.Size = new System.Drawing.Size(220, 23);
            this.txtInvoice.TabIndex = 7;
            // 
            // grpLines
            // 
            this.grpLines.Controls.Add(this.lblProduct);
            this.grpLines.Controls.Add(this.txtProduct);
            this.grpLines.Controls.Add(this.lblUnit);
            this.grpLines.Controls.Add(this.txtUnit);
            this.grpLines.Controls.Add(this.lblQuantity);
            this.grpLines.Controls.Add(this.numQuantity);
            this.grpLines.Controls.Add(this.lblPrice);
            this.grpLines.Controls.Add(this.numPrice);
            this.grpLines.Controls.Add(this.btnAddLine);
            this.grpLines.Controls.Add(this.dgvLines);
            this.grpLines.Controls.Add(this.btnRemoveLine);
            this.grpLines.Location = new System.Drawing.Point(16, 88);
            this.grpLines.Name = "grpLines";
            this.grpLines.Size = new System.Drawing.Size(728, 330);
            this.grpLines.TabIndex = 8;
            this.grpLines.Text = "Позиции накладной";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Location = new System.Drawing.Point(12, 30);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.TabIndex = 9;
            this.lblProduct.Text = "Товар:";
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(60, 26);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(190, 23);
            this.txtProduct.TabIndex = 10;
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(260, 30);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.TabIndex = 11;
            this.lblUnit.Text = "Ед.:";
            // 
            // txtUnit
            // 
            this.txtUnit.Text = "кг";
            this.txtUnit.Location = new System.Drawing.Point(288, 26);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(50, 23);
            this.txtUnit.TabIndex = 12;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(348, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.TabIndex = 13;
            this.lblQuantity.Text = "Кол-во:";
            // 
            // numQuantity
            // 
            this.numQuantity.DecimalPlaces = 3;
            this.numQuantity.Increment = new decimal(new int[] {1, 0, 0, 196608});
            this.numQuantity.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.numQuantity.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numQuantity.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numQuantity.Location = new System.Drawing.Point(402, 26);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(80, 23);
            this.numQuantity.TabIndex = 14;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(492, 30);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 15;
            this.lblPrice.Text = "Цена:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numPrice.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
            this.numPrice.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numPrice.Location = new System.Drawing.Point(530, 26);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(90, 23);
            this.numPrice.TabIndex = 16;
            // 
            // btnAddLine
            // 
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Location = new System.Drawing.Point(630, 24);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(86, 27);
            this.btnAddLine.TabIndex = 17;
            this.btnAddLine.Text = "Добавить";
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
            this.dgvLines.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colName,
            this.colUnit,
            this.colQuantity,
            this.colPrice,
            this.colSum});
            this.dgvLines.MultiSelect = false;
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Location = new System.Drawing.Point(12, 62);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.Size = new System.Drawing.Size(704, 220);
            this.dgvLines.TabIndex = 18;
            // 
            // colName
            // 
            this.colName.HeaderText = "Товар";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // colUnit
            // 
            this.colUnit.HeaderText = "Ед.";
            this.colUnit.Name = "colUnit";
            this.colUnit.ReadOnly = true;
            this.colUnit.Width = 60;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Количество";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 100;
            this.colQuantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Цена, руб.";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 100;
            this.colPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // colSum
            // 
            this.colSum.HeaderText = "Сумма, руб.";
            this.colSum.Name = "colSum";
            this.colSum.ReadOnly = true;
            this.colSum.Width = 110;
            this.colSum.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.UseVisualStyleBackColor = true;
            this.btnRemoveLine.Location = new System.Drawing.Point(12, 290);
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(130, 27);
            this.btnRemoveLine.TabIndex = 19;
            this.btnRemoveLine.Text = "Удалить строку";
            this.btnRemoveLine.Click += new System.EventHandler(this.btnRemoveLine_Click);
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(16, 434);
            this.lblComment.Name = "lblComment";
            this.lblComment.TabIndex = 20;
            this.lblComment.Text = "Комментарий:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(110, 430);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(634, 23);
            this.txtComment.TabIndex = 21;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(330, 474);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 22;
            this.lblTotal.Text = "Итого по накладной: 0,00 руб.";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // btnOk
            // 
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Location = new System.Drawing.Point(548, 522);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 32);
            this.btnOk.TabIndex = 23;
            this.btnOk.Text = "Сохранить";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(652, 522);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Отмена";
            // 
            // PurchaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 570);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblInvoice);
            this.Controls.Add(this.txtInvoice);
            this.Controls.Add(this.grpLines);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.CancelButton = this.btnCancel;
            this.Name = "PurchaseForm";
            this.Text = "Закупка у поставщика";
            this.grpLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblInvoice;
        private System.Windows.Forms.TextBox txtInvoice;
        private System.Windows.Forms.GroupBox grpLines;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSum;
        private System.Windows.Forms.Button btnRemoveLine;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
