namespace CafeFinance.UI
{
    partial class MainForm
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileDemo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperations = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewSale = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNewExpense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCatalogs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDishes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblKind = new System.Windows.Forms.Label();
            this.cmbKind = new System.Windows.Forms.ComboBox();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmountFrom = new System.Windows.Forms.TextBox();
            this.lblAmountTo = new System.Windows.Forms.Label();
            this.txtAmountTo = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.lblSort = new System.Windows.Forms.Label();
            this.cmbSort = new System.Windows.Forms.ComboBox();
            this.chkDescending = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvOperations = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEmployee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddSale = new System.Windows.Forms.Button();
            this.btnAddPurchase = new System.Windows.Forms.Button();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.grpSummary = new System.Windows.Forms.GroupBox();
            this.lblIncome = new System.Windows.Forms.Label();
            this.lblExpense = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitability = new System.Windows.Forms.Label();
            this.statusMain = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).BeginInit();
            this.menuMain.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpSummary.SuspendLayout();
            this.statusMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuOperations,
            this.menuCatalogs,
            this.menuReports,
            this.menuHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1180, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.menuFileDelete,
            this.menuFileDemo,
            this.toolStripSeparator1,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Text = "Файл";
            // 
            // menuFileNew
            // 
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Text = "Создать файл данных…";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Text = "Открыть…";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Text = "Сохранить";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            this.menuFileSaveAs.Text = "Сохранить как…";
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // menuFileDelete
            // 
            this.menuFileDelete.Name = "menuFileDelete";
            this.menuFileDelete.Text = "Удалить файл данных…";
            this.menuFileDelete.Click += new System.EventHandler(this.menuFileDelete_Click);
            // 
            // menuFileDemo
            // 
            this.menuFileDemo.Name = "menuFileDemo";
            this.menuFileDemo.Text = "Загрузить демонстрационные данные";
            this.menuFileDemo.Click += new System.EventHandler(this.menuFileDemo_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            this.menuFileExit.Text = "Выход";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuOperations
            // 
            this.menuOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNewSale,
            this.menuNewPurchase,
            this.menuNewExpense,
            this.toolStripSeparator2,
            this.menuEdit,
            this.menuDelete});
            this.menuOperations.Name = "menuOperations";
            this.menuOperations.Text = "Операции";
            // 
            // menuNewSale
            // 
            this.menuNewSale.Name = "menuNewSale";
            this.menuNewSale.Text = "Новая продажа…";
            this.menuNewSale.Click += new System.EventHandler(this.btnAddSale_Click);
            // 
            // menuNewPurchase
            // 
            this.menuNewPurchase.Name = "menuNewPurchase";
            this.menuNewPurchase.Text = "Новая закупка…";
            this.menuNewPurchase.Click += new System.EventHandler(this.btnAddPurchase_Click);
            // 
            // menuNewExpense
            // 
            this.menuNewExpense.Name = "menuNewExpense";
            this.menuNewExpense.Text = "Новый расход…";
            this.menuNewExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Text = "Изменить выбранную…";
            this.menuEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // menuDelete
            // 
            this.menuDelete.Name = "menuDelete";
            this.menuDelete.Text = "Удалить выбранную";
            this.menuDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // menuCatalogs
            // 
            this.menuCatalogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDishes});
            this.menuCatalogs.Name = "menuCatalogs";
            this.menuCatalogs.Text = "Справочники";
            // 
            // menuDishes
            // 
            this.menuDishes.Name = "menuDishes";
            this.menuDishes.Text = "Меню кафе…";
            this.menuDishes.Click += new System.EventHandler(this.menuDishes_Click);
            // 
            // menuReports
            // 
            this.menuReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuReport});
            this.menuReports.Name = "menuReports";
            this.menuReports.Text = "Отчёты";
            // 
            // menuReport
            // 
            this.menuReport.Name = "menuReport";
            this.menuReport.Text = "Финансовый отчёт за период…";
            this.menuReport.Click += new System.EventHandler(this.menuReport_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Text = "Справка";
            // 
            // menuAbout
            // 
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Text = "О программе";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(266, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(266, 6);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblKind);
            this.grpSearch.Controls.Add(this.cmbKind);
            this.grpSearch.Controls.Add(this.lblDateFrom);
            this.grpSearch.Controls.Add(this.dtpFrom);
            this.grpSearch.Controls.Add(this.lblDateTo);
            this.grpSearch.Controls.Add(this.dtpTo);
            this.grpSearch.Controls.Add(this.lblAmount);
            this.grpSearch.Controls.Add(this.txtAmountFrom);
            this.grpSearch.Controls.Add(this.lblAmountTo);
            this.grpSearch.Controls.Add(this.txtAmountTo);
            this.grpSearch.Controls.Add(this.btnFind);
            this.grpSearch.Controls.Add(this.lblSort);
            this.grpSearch.Controls.Add(this.cmbSort);
            this.grpSearch.Controls.Add(this.chkDescending);
            this.grpSearch.Controls.Add(this.btnReset);
            this.grpSearch.Location = new System.Drawing.Point(12, 30);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1156, 118);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.Text = "Поиск и сортировка";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(12, 28);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.TabIndex = 2;
            this.lblSearch.Text = "Текст:";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(220, 23);
            this.txtSearch.TabIndex = 3;
            // 
            // lblKind
            // 
            this.lblKind.AutoSize = true;
            this.lblKind.Location = new System.Drawing.Point(295, 28);
            this.lblKind.Name = "lblKind";
            this.lblKind.TabIndex = 4;
            this.lblKind.Text = "Вид:";
            // 
            // cmbKind
            // 
            this.cmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKind.FormattingEnabled = true;
            this.cmbKind.Location = new System.Drawing.Point(332, 24);
            this.cmbKind.Name = "cmbKind";
            this.cmbKind.Size = new System.Drawing.Size(130, 23);
            this.cmbKind.TabIndex = 5;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(478, 28);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.TabIndex = 6;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Checked = false;
            this.dtpFrom.Location = new System.Drawing.Point(532, 24);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 23);
            this.dtpFrom.TabIndex = 7;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(664, 28);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.TabIndex = 8;
            this.lblDateTo.Text = "по:";
            // 
            // dtpTo
            // 
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Checked = false;
            this.dtpTo.Location = new System.Drawing.Point(690, 24);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 23);
            this.dtpTo.TabIndex = 9;
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(824, 28);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "Сумма от:";
            // 
            // txtAmountFrom
            // 
            this.txtAmountFrom.Location = new System.Drawing.Point(884, 24);
            this.txtAmountFrom.Name = "txtAmountFrom";
            this.txtAmountFrom.Size = new System.Drawing.Size(62, 23);
            this.txtAmountFrom.TabIndex = 11;
            // 
            // lblAmountTo
            // 
            this.lblAmountTo.AutoSize = true;
            this.lblAmountTo.Location = new System.Drawing.Point(954, 28);
            this.lblAmountTo.Name = "lblAmountTo";
            this.lblAmountTo.TabIndex = 12;
            this.lblAmountTo.Text = "до:";
            // 
            // txtAmountTo
            // 
            this.txtAmountTo.Location = new System.Drawing.Point(980, 24);
            this.txtAmountTo.Name = "txtAmountTo";
            this.txtAmountTo.Size = new System.Drawing.Size(62, 23);
            this.txtAmountTo.TabIndex = 13;
            // 
            // btnFind
            // 
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Location = new System.Drawing.Point(1058, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(86, 27);
            this.btnFind.TabIndex = 14;
            this.btnFind.Text = "Найти";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // lblSort
            // 
            this.lblSort.AutoSize = true;
            this.lblSort.Location = new System.Drawing.Point(12, 76);
            this.lblSort.Name = "lblSort";
            this.lblSort.TabIndex = 15;
            this.lblSort.Text = "Сортировка:";
            // 
            // cmbSort
            // 
            this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSort.FormattingEnabled = true;
            this.cmbSort.Location = new System.Drawing.Point(90, 72);
            this.cmbSort.Name = "cmbSort";
            this.cmbSort.Size = new System.Drawing.Size(170, 23);
            this.cmbSort.TabIndex = 16;
            this.cmbSort.SelectedIndexChanged += new System.EventHandler(this.Sorting_Changed);
            // 
            // chkDescending
            // 
            this.chkDescending.AutoSize = true;
            this.chkDescending.UseVisualStyleBackColor = true;
            this.chkDescending.Location = new System.Drawing.Point(275, 74);
            this.chkDescending.Name = "chkDescending";
            this.chkDescending.Size = new System.Drawing.Size(120, 19);
            this.chkDescending.TabIndex = 17;
            this.chkDescending.Text = "По убыванию";
            this.chkDescending.CheckedChanged += new System.EventHandler(this.Sorting_Changed);
            // 
            // btnReset
            // 
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Location = new System.Drawing.Point(984, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(160, 27);
            this.btnReset.TabIndex = 18;
            this.btnReset.Text = "Сбросить фильтры";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dgvOperations
            // 
            this.dgvOperations.AllowUserToAddRows = false;
            this.dgvOperations.AllowUserToDeleteRows = false;
            this.dgvOperations.AllowUserToResizeRows = false;
            this.dgvOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom));
            this.dgvOperations.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colDate,
            this.colType,
            this.colEmployee,
            this.colDescription,
            this.colAmount});
            this.dgvOperations.MultiSelect = false;
            this.dgvOperations.ReadOnly = true;
            this.dgvOperations.RowHeadersVisible = false;
            this.dgvOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOperations.Location = new System.Drawing.Point(12, 156);
            this.dgvOperations.Name = "dgvOperations";
            this.dgvOperations.Size = new System.Drawing.Size(1156, 400);
            this.dgvOperations.TabIndex = 19;
            this.dgvOperations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperations_CellDoubleClick);
            // 
            // colId
            // 
            this.colId.HeaderText = "№";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Width = 60;
            // 
            // colDate
            // 
            this.colDate.HeaderText = "Дата и время";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.Width = 130;
            // 
            // colType
            // 
            this.colType.HeaderText = "Тип";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Width = 90;
            // 
            // colEmployee
            // 
            this.colEmployee.HeaderText = "Сотрудник";
            this.colEmployee.Name = "colEmployee";
            this.colEmployee.ReadOnly = true;
            this.colEmployee.Width = 160;
            // 
            // colDescription
            // 
            this.colDescription.HeaderText = "Описание";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            this.colDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "Сумма, руб.";
            this.colAmount.Name = "colAmount";
            this.colAmount.ReadOnly = true;
            this.colAmount.Width = 120;
            this.colAmount.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            // 
            // btnAddSale
            // 
            this.btnAddSale.UseVisualStyleBackColor = true;
            this.btnAddSale.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnAddSale.Location = new System.Drawing.Point(12, 566);
            this.btnAddSale.Name = "btnAddSale";
            this.btnAddSale.Size = new System.Drawing.Size(150, 32);
            this.btnAddSale.TabIndex = 20;
            this.btnAddSale.Text = "Добавить продажу";
            this.btnAddSale.Click += new System.EventHandler(this.btnAddSale_Click);
            // 
            // btnAddPurchase
            // 
            this.btnAddPurchase.UseVisualStyleBackColor = true;
            this.btnAddPurchase.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnAddPurchase.Location = new System.Drawing.Point(170, 566);
            this.btnAddPurchase.Name = "btnAddPurchase";
            this.btnAddPurchase.Size = new System.Drawing.Size(150, 32);
            this.btnAddPurchase.TabIndex = 21;
            this.btnAddPurchase.Text = "Добавить закупку";
            this.btnAddPurchase.Click += new System.EventHandler(this.btnAddPurchase_Click);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.btnAddExpense.Location = new System.Drawing.Point(328, 566);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(150, 32);
            this.btnAddExpense.TabIndex = 22;
            this.btnAddExpense.Text = "Добавить расход";
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnEdit.Location = new System.Drawing.Point(996, 566);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 32);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
            this.btnDelete.Location = new System.Drawing.Point(1088, 566);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 32);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grpSummary
            // 
            this.grpSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.grpSummary.Controls.Add(this.lblIncome);
            this.grpSummary.Controls.Add(this.lblExpense);
            this.grpSummary.Controls.Add(this.lblProfit);
            this.grpSummary.Controls.Add(this.lblProfitability);
            this.grpSummary.Location = new System.Drawing.Point(12, 606);
            this.grpSummary.Name = "grpSummary";
            this.grpSummary.Size = new System.Drawing.Size(1156, 56);
            this.grpSummary.TabIndex = 25;
            this.grpSummary.Text = "Итоги по отображаемым операциям";
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.Location = new System.Drawing.Point(16, 25);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.TabIndex = 26;
            this.lblIncome.Text = "Доходы: 0,00 руб.";
            // 
            // lblExpense
            // 
            this.lblExpense.AutoSize = true;
            this.lblExpense.Location = new System.Drawing.Point(290, 25);
            this.lblExpense.Name = "lblExpense";
            this.lblExpense.TabIndex = 27;
            this.lblExpense.Text = "Расходы: 0,00 руб.";
            // 
            // lblProfit
            // 
            this.lblProfit.AutoSize = true;
            this.lblProfit.Location = new System.Drawing.Point(564, 25);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.TabIndex = 28;
            this.lblProfit.Text = "Прибыль: 0,00 руб.";
            // 
            // lblProfitability
            // 
            this.lblProfitability.AutoSize = true;
            this.lblProfitability.Location = new System.Drawing.Point(838, 25);
            this.lblProfitability.Name = "lblProfitability";
            this.lblProfitability.TabIndex = 29;
            this.lblProfitability.Text = "Рентабельность: 0,00 %";
            // 
            // statusMain
            // 
            this.statusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusMain.Location = new System.Drawing.Point(0, 668);
            this.statusMain.Name = "statusMain";
            this.statusMain.Size = new System.Drawing.Size(1180, 22);
            this.statusMain.TabIndex = 30;
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Text = "Файл данных не открыт";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 690);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.dgvOperations);
            this.Controls.Add(this.btnAddSale);
            this.Controls.Add(this.btnAddPurchase);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpSummary);
            this.Controls.Add(this.statusMain);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MainMenuStrip = this.menuMain;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "MainForm";
            this.Text = "Кафе ПолесГУ — финансовый учёт";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusMain.ResumeLayout(false);
            this.statusMain.PerformLayout();
            this.grpSummary.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuFileDelete;
        private System.Windows.Forms.ToolStripMenuItem menuFileDemo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuOperations;
        private System.Windows.Forms.ToolStripMenuItem menuNewSale;
        private System.Windows.Forms.ToolStripMenuItem menuNewPurchase;
        private System.Windows.Forms.ToolStripMenuItem menuNewExpense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuDelete;
        private System.Windows.Forms.ToolStripMenuItem menuCatalogs;
        private System.Windows.Forms.ToolStripMenuItem menuDishes;
        private System.Windows.Forms.ToolStripMenuItem menuReports;
        private System.Windows.Forms.ToolStripMenuItem menuReport;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblKind;
        private System.Windows.Forms.ComboBox cmbKind;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmountFrom;
        private System.Windows.Forms.Label lblAmountTo;
        private System.Windows.Forms.TextBox txtAmountTo;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Label lblSort;
        private System.Windows.Forms.ComboBox cmbSort;
        private System.Windows.Forms.CheckBox chkDescending;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvOperations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.Button btnAddSale;
        private System.Windows.Forms.Button btnAddPurchase;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox grpSummary;
        private System.Windows.Forms.Label lblIncome;
        private System.Windows.Forms.Label lblExpense;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblProfitability;
        private System.Windows.Forms.StatusStrip statusMain;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}
