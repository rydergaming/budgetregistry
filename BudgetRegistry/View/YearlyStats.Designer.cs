namespace BudgetRegistry.View
{
    partial class YearlyStats
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
            this.allTimeDataGrid = new System.Windows.Forms.DataGridView();
            this.yearlyDataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.allTimeDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // allTimeDataGrid
            // 
            this.allTimeDataGrid.AllowUserToAddRows = false;
            this.allTimeDataGrid.AllowUserToDeleteRows = false;
            this.allTimeDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allTimeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTimeDataGrid.Location = new System.Drawing.Point(12, 12);
            this.allTimeDataGrid.Name = "allTimeDataGrid";
            this.allTimeDataGrid.ReadOnly = true;
            this.allTimeDataGrid.Size = new System.Drawing.Size(630, 164);
            this.allTimeDataGrid.TabIndex = 2;
            this.allTimeDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allTimeDataGrid_CellClick);
            // 
            // yearlyDataGrid
            // 
            this.yearlyDataGrid.AllowUserToAddRows = false;
            this.yearlyDataGrid.AllowUserToDeleteRows = false;
            this.yearlyDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yearlyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yearlyDataGrid.Location = new System.Drawing.Point(12, 182);
            this.yearlyDataGrid.Name = "yearlyDataGrid";
            this.yearlyDataGrid.ReadOnly = true;
            this.yearlyDataGrid.Size = new System.Drawing.Size(630, 147);
            this.yearlyDataGrid.TabIndex = 3;
            // 
            // YearlyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 373);
            this.Controls.Add(this.yearlyDataGrid);
            this.Controls.Add(this.allTimeDataGrid);
            this.Name = "YearlyStats";
            this.Text = "Yearly Statistics";
            this.Load += new System.EventHandler(this.YearlyStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allTimeDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView allTimeDataGrid;
        private System.Windows.Forms.DataGridView yearlyDataGrid;
    }
}