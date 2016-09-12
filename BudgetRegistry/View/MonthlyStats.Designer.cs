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
            ((System.ComponentModel.ISupportInitialize)(this.monthlyStatGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthCategoryGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // monthlyStatGrid
            // 
            this.monthlyStatGrid.AllowUserToAddRows = false;
            this.monthlyStatGrid.AllowUserToDeleteRows = false;
            this.monthlyStatGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthlyStatGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthlyStatGrid.Location = new System.Drawing.Point(12, 38);
            this.monthlyStatGrid.Name = "monthlyStatGrid";
            this.monthlyStatGrid.ReadOnly = true;
            this.monthlyStatGrid.Size = new System.Drawing.Size(638, 146);
            this.monthlyStatGrid.TabIndex = 0;
            this.monthlyStatGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.monthlyStatGrid_CellClick);
            // 
            // monthCategoryGrid
            // 
            this.monthCategoryGrid.AllowUserToAddRows = false;
            this.monthCategoryGrid.AllowUserToDeleteRows = false;
            this.monthCategoryGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCategoryGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.monthCategoryGrid.Location = new System.Drawing.Point(12, 205);
            this.monthCategoryGrid.Name = "monthCategoryGrid";
            this.monthCategoryGrid.ReadOnly = true;
            this.monthCategoryGrid.Size = new System.Drawing.Size(638, 133);
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
            // MonthlyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 350);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.monthCategoryGrid);
            this.Controls.Add(this.monthlyStatGrid);
            this.Name = "MonthlyStats";
            this.Text = "Monthly Statistics";
            this.Load += new System.EventHandler(this.MonthlyStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monthlyStatGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthCategoryGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView monthlyStatGrid;
        private System.Windows.Forms.DataGridView monthCategoryGrid;
        private System.Windows.Forms.NumericUpDown yearNumericUpDown;
        private System.Windows.Forms.Label yearLabel;
    }
}