namespace CafeFinance.UI
{
    partial class DishCatalogForm
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
            this.dgvDishes = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.lblCost = new System.Windows.Forms.Label();
            this.numCost = new System.Windows.Forms.NumericUpDown();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).BeginInit();
            this.grpEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDishes
            // 
            this.dgvDishes.AllowUserToAddRows = false;
            this.dgvDishes.AllowUserToDeleteRows = false;
            this.dgvDishes.AllowUserToResizeRows = false;
            this.dgvDishes.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
            this.dgvDishes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDishes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colName,
            this.colCategory,
            this.colPrice,
            this.colCost});
            this.dgvDishes.MultiSelect = false;
            this.dgvDishes.ReadOnly = true;
            this.dgvDishes.RowHeadersVisible = false;
            this.dgvDishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDishes.Location = new System.Drawing.Point(12, 12);
            this.dgvDishes.Name = "dgvDishes";
            this.dgvDishes.Size = new System.Drawing.Size(676, 300);
            this.dgvDishes.TabIndex = 0;
            this.dgvDishes.SelectionChanged += new System.EventHandler(this.dgvDishes_SelectionChanged);
            // 
            // colId
            // 
            this.colId.HeaderText = "№";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "Наименование";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // colCategory
            // 
            this.colCategory.HeaderText = "Категория";
            this.colCategory.Name = "colCategory";
            this.colCategory.ReadOnly = true;
            this.colCategory.Width = 140;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "Цена, руб.";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            this.colPrice.Width = 90;
            this.colPrice.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "Себестоимость, руб.";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 130;
            this.colCost.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // grpEdit
            // 
            this.grpEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.grpEdit.Controls.Add(this.lblName);
            this.grpEdit.Controls.Add(this.txtName);
            this.grpEdit.Controls.Add(this.lblCategory);
            this.grpEdit.Controls.Add(this.cmbCategory);
            this.grpEdit.Controls.Add(this.lblPrice);
            this.grpEdit.Controls.Add(this.numPrice);
            this.grpEdit.Controls.Add(this.lblCost);
            this.grpEdit.Controls.Add(this.numCost);
            this.grpEdit.Controls.Add(this.btnAdd);
            this.grpEdit.Controls.Add(this.btnUpdate);
            this.grpEdit.Controls.Add(this.btnDelete);
            this.grpEdit.Location = new System.Drawing.Point(12, 322);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(676, 140);
            this.grpEdit.TabIndex = 1;
            this.grpEdit.Text = "Данные блюда";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 32);
            this.lblName.Name = "lblName";
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Наименование:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(112, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(270, 23);
            this.txtName.TabIndex = 3;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(402, 32);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.TabIndex = 4;
            this.lblCategory.Text = "Категория:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(472, 28);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(190, 23);
            this.cmbCategory.TabIndex = 5;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(12, 72);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Цена, руб.:";
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numPrice.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.numPrice.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numPrice.Location = new System.Drawing.Point(112, 68);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(90, 23);
            this.numPrice.TabIndex = 7;
            // 
            // lblCost
            // 
            this.lblCost.AutoSize = true;
            this.lblCost.Location = new System.Drawing.Point(232, 72);
            this.lblCost.Name = "lblCost";
            this.lblCost.TabIndex = 8;
            this.lblCost.Text = "Себестоимость, руб.:";
            // 
            // numCost
            // 
            this.numCost.DecimalPlaces = 2;
            this.numCost.Increment = new decimal(new int[] {1, 0, 0, 131072});
            this.numCost.Maximum = new decimal(new int[] {100000, 0, 0, 0});
            this.numCost.Minimum = new decimal(new int[] {0, 0, 0, 0});
            this.numCost.Location = new System.Drawing.Point(366, 68);
            this.numCost.Name = "numCost";
            this.numCost.Size = new System.Drawing.Size(90, 23);
            this.numCost.TabIndex = 9;
            // 
            // btnAdd
            // 
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Location = new System.Drawing.Point(12, 100);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 30);
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Location = new System.Drawing.Point(120, 100);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 30);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Location = new System.Drawing.Point(228, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnClose.Location = new System.Drawing.Point(588, 476);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 32);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Закрыть";
            // 
            // DishCatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 520);
            this.Controls.Add(this.dgvDishes);
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.CancelButton = this.btnClose;
            this.Name = "DishCatalogForm";
            this.Text = "Меню кафе";
            this.grpEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDishes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.NumericUpDown numCost;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClose;
    }
}
