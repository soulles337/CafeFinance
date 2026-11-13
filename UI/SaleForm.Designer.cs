namespace CafeFinance.UI
{
    partial class SaleForm
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
            this.lblPayment = new System.Windows.Forms.Label();
            this.cmbPayment = new System.Windows.Forms.ComboBox();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.numDiscount = new System.Windows.Forms.NumericUpDown();
            this.grpLines = new System.Windows.Forms.GroupBox();
            this.lblDish = new System.Windows.Forms.Label();
            this.cmbDish = new System.Windows.Forms.ComboBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.numQuantity = new System.Windows.Forms.NumericUpDown();
            this.btnAddLine = new System.Windows.Forms.Button();
            this.btnRemoveLine = new System.Windows.Forms.Button();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblComment = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).BeginInit();
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
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.Location = new System.Drawing.Point(16, 54);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.TabIndex = 4;
            this.lblPayment.Text = "Оплата:";
            // 
            // cmbPayment
            // 
            this.cmbPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayment.FormattingEnabled = true;
            this.cmbPayment.Location = new System.Drawing.Point(110, 50);
            this.cmbPayment.Name = "cmbPayment";
            this.cmbPayment.Size = new System.Drawing.Size(190, 23);
            this.cmbPayment.TabIndex = 5;
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.Location = new System.Drawing.Point(330, 54);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.TabIndex = 6;
            this.lblDiscount.Text = "Скидка, %:";
            // 
            // numDiscount
            // 
            this.numDiscount.DecimalPlaces = 1;
            this.numDiscount.Increment = new decimal(new int[] {1, 0, 0, 65536});
            this.numDiscount.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.numDiscount.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numDiscount.Location = new System.Drawing.Point(410, 50);
            this.numDiscount.Name = "numDiscount";
            this.numDiscount.Size = new System.Drawing.Size(80, 23);
            this.numDiscount.TabIndex = 7;
            this.numDiscount.ValueChanged += new System.EventHandler(this.numDiscount_ValueChanged);
            // 
            // grpLines
            // 
            this.grpLines.Controls.Add(this.lblDish);
            this.grpLines.Controls.Add(this.cmbDish);
            this.grpLines.Controls.Add(this.lblQuantity);
            this.grpLines.Controls.Add(this.numQuantity);
            this.grpLines.Controls.Add(this.btnAddLine);
            this.grpLines.Controls.Add(this.btnRemoveLine);
            this.grpLines.Controls.Add(this.dgvLines);
            this.grpLines.Location = new System.Drawing.Point(16, 88);
            this.grpLines.Name = "grpLines";
            this.grpLines.Size = new System.Drawing.Size(728, 330);
            this.grpLines.TabIndex = 8;
            this.grpLines.Text = "Позиции чека";
            // 
            // lblDish
            // 
            this.lblDish.AutoSize = true;
            this.lblDish.Location = new System.Drawing.Point(12, 30);
            this.lblDish.Name = "lblDish";
            this.lblDish.TabIndex = 9;
            this.lblDish.Text = "Блюдо:";
            // 
            // cmbDish
            // 
            this.cmbDish.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDish.FormattingEnabled = true;
            this.cmbDish.Location = new System.Drawing.Point(62, 26);
            this.cmbDish.Name = "cmbDish";
            this.cmbDish.Size = new System.Drawing.Size(330, 23);
            this.cmbDish.TabIndex = 10;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(404, 30);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.TabIndex = 11;
            this.lblQuantity.Text = "Кол-во:";
            // 
            // numQuantity
            // 
            this.numQuantity.DecimalPlaces = 0;
            this.numQuantity.Maximum = new decimal(new int[] {100, 0, 0, 0});
            this.numQuantity.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numQuantity.Value = new decimal(new int[] {1, 0, 0, 0});
            this.numQuantity.Location = new System.Drawing.Point(458, 26);
            this.numQuantity.Name = "numQuantity";
            this.numQuantity.Size = new System.Drawing.Size(60, 23);
            this.numQuantity.TabIndex = 12;
            // 
            // btnAddLine
            // 
            this.btnAddLine.UseVisualStyleBackColor = true;
            this.btnAddLine.Location = new System.Drawing.Point(534, 24);
            this.btnAddLine.Name = "btnAddLine";
            this.btnAddLine.Size = new System.Drawing.Size(90, 27);
            this.btnAddLine.TabIndex = 13;
            this.btnAddLine.Text = "Добавить";
            this.btnAddLine.Click += new System.EventHandler(this.btnAddLine_Click);
            // 
            // btnRemoveLine
            // 
            this.btnRemoveLine.UseVisualStyleBackColor = true;
            this.btnRemoveLine.Location = new System.Drawing.Point(632, 24);
            this.btnRemoveLine.Name = "btnRemoveLine";
            this.btnRemoveLine.Size = new System.Drawing.Size(84, 27);
            this.btnRemoveLine.TabIndex = 14;
            this.btnRemoveLine.Text = "Удалить";
            this.btnRemoveLine.Click += new System.EventHandler(this.btnRemoveLine_Click);
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
            this.colPrice,
            this.colQuantity,
            this.colSum});
            this.dgvLines.MultiSelect = false;
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Location = new System.Drawing.Point(12, 62);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.Size = new System.Drawing.Size(704, 256);
            this.dgvLines.TabIndex = 15;
            // 
            // colName
            // 
            this.colName.HeaderText = "Блюдо";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Цена, руб.";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 100;
            this.colPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // colQuantity
            // 
            this.colQuantity.HeaderText = "Кол-во";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 80;
            this.colQuantity.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // colSum
            // 
            this.colSum.HeaderText = "Сумма, руб.";
            this.colSum.Name = "colSum";
            this.colSum.ReadOnly = true;
            this.colSum.Width = 110;
            this.colSum.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(16, 434);
            this.lblComment.Name = "lblComment";
            this.lblComment.TabIndex = 16;
            this.lblComment.Text = "Комментарий:";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(110, 430);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(634, 23);
            this.txtComment.TabIndex = 17;
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Location = new System.Drawing.Point(16, 470);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.TabIndex = 18;
            this.lblSubtotal.Text = "Сумма без скидки: 0,00 руб.";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(330, 466);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.TabIndex = 19;
            this.lblTotal.Text = "Итого к оплате: 0,00 руб.";
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            // 
            // btnOk
            // 
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Location = new System.Drawing.Point(548, 512);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(96, 32);
            this.btnOk.TabIndex = 20;
            this.btnOk.Text = "Сохранить";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(652, 512);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(92, 32);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Отмена";
            // 
            // SaleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 560);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.cmbEmployee);
            this.Controls.Add(this.lblPayment);
            this.Controls.Add(this.cmbPayment);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.numDiscount);
            this.Controls.Add(this.grpLines);
            this.Controls.Add(this.lblComment);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.lblSubtotal);
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
            this.Name = "SaleForm";
            this.Text = "Продажа (кассовый чек)";
            this.grpLines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numDiscount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.ComboBox cmbEmployee;
        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.ComboBox cmbPayment;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.NumericUpDown numDiscount;
        private System.Windows.Forms.GroupBox grpLines;
        private System.Windows.Forms.Label lblDish;
        private System.Windows.Forms.ComboBox cmbDish;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown numQuantity;
        private System.Windows.Forms.Button btnAddLine;
        private System.Windows.Forms.Button btnRemoveLine;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSum;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
    }
}
