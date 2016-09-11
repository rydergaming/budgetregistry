namespace BudgetRegistry
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.loadSpendingItemButton = new DevExpress.XtraBars.BarButtonItem();
            this.addSpendingItem = new DevExpress.XtraBars.BarButtonItem();
            this.spendingItemsButton = new DevExpress.XtraBars.BarButtonItem();
            this.spendingButton = new DevExpress.XtraBars.BarButtonItem();
            this.loginButton = new DevExpress.XtraBars.BarButtonItem();
            this.addSpendingButton = new DevExpress.XtraBars.BarButtonItem();
            this.loadSpendingsButton = new DevExpress.XtraBars.BarButtonItem();
            this.monthlyStatsButton = new DevExpress.XtraBars.BarButtonItem();
            this.yearlyStatsButton = new DevExpress.XtraBars.BarButtonItem();
            this.exportAllSpending = new DevExpress.XtraBars.BarButtonItem();
            this.spendingRibbonPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.viewSpending = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statisticsPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.statsMonthly = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.usersPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.usersRibbonGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLoad = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLoadSpending = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundItemWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundSpendingWorker = new System.ComponentModel.BackgroundWorker();
            this.backgroundExportWorker = new System.ComponentModel.BackgroundWorker();
            this.IncomeGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.addIncome = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.loadSpendingItemButton,
            this.addSpendingItem,
            this.spendingItemsButton,
            this.spendingButton,
            this.loginButton,
            this.addSpendingButton,
            this.loadSpendingsButton,
            this.monthlyStatsButton,
            this.yearlyStatsButton,
            this.exportAllSpending,
            this.addIncome});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 15;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.spendingRibbonPage,
            this.statisticsPage,
            this.usersPage});
            this.ribbonControl1.Size = new System.Drawing.Size(758, 143);
            // 
            // loadSpendingItemButton
            // 
            this.loadSpendingItemButton.Caption = "Load Spending Items";
            this.loadSpendingItemButton.Glyph = ((System.Drawing.Image)(resources.GetObject("loadSpendingItemButton.Glyph")));
            this.loadSpendingItemButton.Id = 3;
            this.loadSpendingItemButton.Name = "loadSpendingItemButton";
            this.loadSpendingItemButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.loadSpendingItemButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.loadSpendingItemButton_ItemClick);
            // 
            // addSpendingItem
            // 
            this.addSpendingItem.Caption = "Add/Edit Spending Item";
            this.addSpendingItem.Glyph = ((System.Drawing.Image)(resources.GetObject("addSpendingItem.Glyph")));
            this.addSpendingItem.Id = 4;
            this.addSpendingItem.Name = "addSpendingItem";
            this.addSpendingItem.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.addSpendingItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addSpendingItem_ItemClick);
            // 
            // spendingItemsButton
            // 
            this.spendingItemsButton.Caption = "Spending Items";
            this.spendingItemsButton.Glyph = ((System.Drawing.Image)(resources.GetObject("spendingItemsButton.Glyph")));
            this.spendingItemsButton.Id = 5;
            this.spendingItemsButton.Name = "spendingItemsButton";
            this.spendingItemsButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.spendingItemsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.spendingItemsButton_ItemClick);
            // 
            // spendingButton
            // 
            this.spendingButton.Caption = "Spendings";
            this.spendingButton.Glyph = ((System.Drawing.Image)(resources.GetObject("spendingButton.Glyph")));
            this.spendingButton.Id = 6;
            this.spendingButton.Name = "spendingButton";
            this.spendingButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.spendingButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.spendingButton_ItemClick);
            // 
            // loginButton
            // 
            this.loginButton.Caption = "Switch/Add User";
            this.loginButton.Glyph = ((System.Drawing.Image)(resources.GetObject("loginButton.Glyph")));
            this.loginButton.Id = 8;
            this.loginButton.Name = "loginButton";
            this.loginButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.loginButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.loginButton_ItemClick);
            // 
            // addSpendingButton
            // 
            this.addSpendingButton.Caption = "Add Spending";
            this.addSpendingButton.Glyph = ((System.Drawing.Image)(resources.GetObject("addSpendingButton.Glyph")));
            this.addSpendingButton.Id = 9;
            this.addSpendingButton.Name = "addSpendingButton";
            this.addSpendingButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.addSpendingButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addSpendingButton_ItemClick);
            // 
            // loadSpendingsButton
            // 
            this.loadSpendingsButton.Caption = "Load Spendings";
            this.loadSpendingsButton.Glyph = ((System.Drawing.Image)(resources.GetObject("loadSpendingsButton.Glyph")));
            this.loadSpendingsButton.Id = 10;
            this.loadSpendingsButton.Name = "loadSpendingsButton";
            this.loadSpendingsButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.loadSpendingsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.loadSpendingsButton_ItemClick);
            // 
            // monthlyStatsButton
            // 
            this.monthlyStatsButton.Caption = "Monthly Statistics";
            this.monthlyStatsButton.Glyph = ((System.Drawing.Image)(resources.GetObject("monthlyStatsButton.Glyph")));
            this.monthlyStatsButton.Id = 11;
            this.monthlyStatsButton.Name = "monthlyStatsButton";
            this.monthlyStatsButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.monthlyStatsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.monthlyStatsButton_ItemClick);
            // 
            // yearlyStatsButton
            // 
            this.yearlyStatsButton.Caption = "Yearly Statistics";
            this.yearlyStatsButton.Glyph = ((System.Drawing.Image)(resources.GetObject("yearlyStatsButton.Glyph")));
            this.yearlyStatsButton.Id = 12;
            this.yearlyStatsButton.Name = "yearlyStatsButton";
            this.yearlyStatsButton.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.yearlyStatsButton.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.yearlyStatsButton_ItemClick);
            // 
            // exportAllSpending
            // 
            this.exportAllSpending.Caption = "Export All Spendings";
            this.exportAllSpending.Glyph = ((System.Drawing.Image)(resources.GetObject("exportAllSpending.Glyph")));
            this.exportAllSpending.Id = 13;
            this.exportAllSpending.Name = "exportAllSpending";
            this.exportAllSpending.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.exportAllSpending.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.exportAllSpending_ItemClick);
            // 
            // spendingRibbonPage
            // 
            this.spendingRibbonPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.viewSpending,
            this.IncomeGroup});
            this.spendingRibbonPage.Name = "spendingRibbonPage";
            this.spendingRibbonPage.Text = "Spending";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Glyph = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.Glyph")));
            this.ribbonPageGroup1.ItemLinks.Add(this.loadSpendingItemButton);
            this.ribbonPageGroup1.ItemLinks.Add(this.addSpendingItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.spendingItemsButton);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // viewSpending
            // 
            this.viewSpending.ItemLinks.Add(this.loadSpendingsButton);
            this.viewSpending.ItemLinks.Add(this.addSpendingButton);
            this.viewSpending.ItemLinks.Add(this.spendingButton);
            this.viewSpending.ItemLinks.Add(this.exportAllSpending);
            this.viewSpending.Name = "viewSpending";
            // 
            // statisticsPage
            // 
            this.statisticsPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.statsMonthly});
            this.statisticsPage.Name = "statisticsPage";
            this.statisticsPage.Text = "Statistics";
            // 
            // statsMonthly
            // 
            this.statsMonthly.ItemLinks.Add(this.monthlyStatsButton);
            this.statsMonthly.ItemLinks.Add(this.yearlyStatsButton);
            this.statsMonthly.Name = "statsMonthly";
            // 
            // usersPage
            // 
            this.usersPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.usersRibbonGroup});
            this.usersPage.Name = "usersPage";
            this.usersPage.Text = "Users";
            // 
            // usersRibbonGroup
            // 
            this.usersRibbonGroup.ItemLinks.Add(this.loginButton);
            this.usersRibbonGroup.Name = "usersRibbonGroup";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLoad,
            this.toolStripStatusLoadSpending});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(758, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLoad
            // 
            this.toolStripStatusLoad.Name = "toolStripStatusLoad";
            this.toolStripStatusLoad.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLoadSpending
            // 
            this.toolStripStatusLoadSpending.Name = "toolStripStatusLoadSpending";
            this.toolStripStatusLoadSpending.Size = new System.Drawing.Size(0, 17);
            // 
            // backgroundItemWorker
            // 
            this.backgroundItemWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundItemWorker_DoWork);
            this.backgroundItemWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundItemWorker_RunWorkerCompleted);
            // 
            // backgroundSpendingWorker
            // 
            this.backgroundSpendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSpendingWorker_DoWork);
            this.backgroundSpendingWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSpendingWorker_RunWorkerCompleted);
            // 
            // backgroundExportWorker
            // 
            this.backgroundExportWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundExportWorker_DoWork);
            this.backgroundExportWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundExportWorker_RunWorkerCompleted);
            // 
            // IncomeGroup
            // 
            this.IncomeGroup.ItemLinks.Add(this.addIncome);
            this.IncomeGroup.Name = "IncomeGroup";
            // 
            // addIncome
            // 
            this.addIncome.Caption = "Add Income";
            this.addIncome.Glyph = ((System.Drawing.Image)(resources.GetObject("addIncome.Glyph")));
            this.addIncome.Id = 14;
            this.addIncome.Name = "addIncome";
            this.addIncome.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.addIncome.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.addIncome_ItemClick);
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 528);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Budget Registry";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem loadSpendingItemButton;
        private DevExpress.XtraBars.Ribbon.RibbonPage spendingRibbonPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem addSpendingItem;
        private DevExpress.XtraBars.Ribbon.RibbonPage statisticsPage;
        private DevExpress.XtraBars.Ribbon.RibbonPage usersPage;
        private DevExpress.XtraBars.BarButtonItem spendingItemsButton;
        private DevExpress.XtraBars.BarButtonItem spendingButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup viewSpending;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private DevExpress.XtraBars.BarButtonItem loginButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup usersRibbonGroup;
        private System.ComponentModel.BackgroundWorker backgroundItemWorker;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoad;
        private DevExpress.XtraBars.BarButtonItem addSpendingButton;
        private DevExpress.XtraBars.BarButtonItem loadSpendingsButton;
        private System.ComponentModel.BackgroundWorker backgroundSpendingWorker;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLoadSpending;
        private DevExpress.XtraBars.BarButtonItem monthlyStatsButton;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup statsMonthly;
        private DevExpress.XtraBars.BarButtonItem yearlyStatsButton;
        private DevExpress.XtraBars.BarButtonItem exportAllSpending;
        private System.ComponentModel.BackgroundWorker backgroundExportWorker;
        private DevExpress.XtraBars.BarButtonItem addIncome;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup IncomeGroup;
    }
}

