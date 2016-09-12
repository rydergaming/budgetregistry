namespace BudgetRegistry.View
{
    partial class MonthlyStats
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
            this.monthlyStatGrid = new System.Windows.Forms.DataGridView();
            this.monthCategoryGrid = new System.Windows.Forms.DataGridView();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.yearLabel = new System.Windows.Forms.Label();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.monthlyStatGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthCategoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // monthlyStatGrid
            // 
            this.monthlyStatGrid.AllowUserToAddRows = false;
            this.monthlyStatGrid.AllowUserToDeleteRows = false;
            this.monthlyStatGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyStatGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthlyStatGrid.Location = new System.Drawing.Point(0, 0);
            this.monthlyStatGrid.Name = "monthlyStatGrid";
            this.monthlyStatGrid.ReadOnly = true;
            this.monthlyStatGrid.Size = new System.Drawing.Size(635, 152);
            this.monthlyStatGrid.TabIndex = 0;
            this.monthlyStatGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.monthlyStatGrid_CellClick);
            // 
            // monthCategoryGrid
            // 
            this.monthCategoryGrid.AllowUserToAddRows = false;
            this.monthCategoryGrid.AllowUserToDeleteRows = false;
            this.monthCategoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthCategoryGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCategoryGrid.Location = new System.Drawing.Point(0, 0);
            this.monthCategoryGrid.Name = "monthCategoryGrid";
            this.monthCategoryGrid.ReadOnly = true;
            this.monthCategoryGrid.Size = new System.Drawing.Size(635, 143);
            this.monthCategoryGrid.TabIndex = 1;
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Location = new System.Drawing.Point(47, 12);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(63, 20);
            this.yearNumericUpDown.TabIndex = 3;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            this.yearNumericUpDown.ValueChanged += new System.EventHandler(this.yearNumericUpDown_ValueChanged);
            // 
            // yearLabel
            // 
            this.yearLabel.AutoSize = true;
            this.yearLabel.Location = new System.Drawing.Point(12, 14);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(29, 13);
            this.yearLabel.TabIndex = 4;
            this.yearLabel.Text = "Year";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(15, 38);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.monthlyStatGrid);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.monthCategoryGrid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(635, 300);
            this.splitContainerControl1.SplitterPosition = 152;
            this.splitContainerControl1.TabIndex = 5;
            this.splitContainerControl1.Text = "splitContainerControl";
            // 
            // MonthlyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 350);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.yearNumericUpDown);
            this.Name = "MonthlyStats";
            this.Text = "Monthly Statistics";
            this.Load += new System.EventHandler(this.MonthlyStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyStatGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthCategoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView monthlyStatGrid;
        private System.Windows.Forms.DataGridView monthCategoryGrid;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.Label yearLabel;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}