namespace BudgetRegistry.View
{
    partial class ViewSpendingItems
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
            this.components = new System.ComponentModel.Container();
            this.spendingGrid = new System.Windows.Forms.DataGridView();
            this.spendingItemSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.spendingGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spendingItemSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spendingGrid
            // 
            this.spendingGrid.AutoGenerateColumns = false;
            this.spendingGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.lastValueDataGridViewTextBoxColumn});
            this.spendingGrid.DataSource = this.spendingItemSource;
            this.spendingGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spendingGrid.Location = new System.Drawing.Point(0, 0);
            this.spendingGrid.Name = "spendingGrid";
            this.spendingGrid.Size = new System.Drawing.Size(657, 320);
            this.spendingGrid.TabIndex = 0;
            this.spendingGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.spendingGrid_CellValueChanged);
            // 
            // spendingItemSource
            // 
            this.spendingItemSource.DataSource = typeof(BudgetRegistry.Model.SpendingItemModel);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // lastValueDataGridViewTextBoxColumn
            // 
            this.lastValueDataGridViewTextBoxColumn.DataPropertyName = "LastValue";
            this.lastValueDataGridViewTextBoxColumn.HeaderText = "LastValue";
            this.lastValueDataGridViewTextBoxColumn.Name = "lastValueDataGridViewTextBoxColumn";
            // 
            // ViewSpendingItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 320);
            this.Controls.Add(this.spendingGrid);
            this.Name = "ViewSpendingItems";
            this.Text = "ViewSpendingItems";
            this.Load += new System.EventHandler(this.ViewSpendingItems_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spendingGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spendingItemSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView spendingGrid;
        public System.Windows.Forms.BindingSource spendingItemSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastValueDataGridViewTextBoxColumn;
    }
}