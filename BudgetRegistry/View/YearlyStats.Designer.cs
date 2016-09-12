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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.allTimeDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // allTimeDataGrid
            // 
            this.allTimeDataGrid.AllowUserToAddRows = false;
            this.allTimeDataGrid.AllowUserToDeleteRows = false;
            this.allTimeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allTimeDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allTimeDataGrid.Location = new System.Drawing.Point(0, 0);
            this.allTimeDataGrid.Name = "allTimeDataGrid";
            this.allTimeDataGrid.ReadOnly = true;
            this.allTimeDataGrid.Size = new System.Drawing.Size(657, 176);
            this.allTimeDataGrid.TabIndex = 2;
            this.allTimeDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allTimeDataGrid_CellClick);
            // 
            // yearlyDataGrid
            // 
            this.yearlyDataGrid.AllowUserToAddRows = false;
            this.yearlyDataGrid.AllowUserToDeleteRows = false;
            this.yearlyDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yearlyDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearlyDataGrid.Location = new System.Drawing.Point(0, 0);
            this.yearlyDataGrid.Name = "yearlyDataGrid";
            this.yearlyDataGrid.ReadOnly = true;
            this.yearlyDataGrid.Size = new System.Drawing.Size(657, 192);
            this.yearlyDataGrid.TabIndex = 3;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.allTimeDataGrid);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.yearlyDataGrid);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(657, 373);
            this.splitContainerControl1.SplitterPosition = 176;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // YearlyStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 373);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "YearlyStats";
            this.Text = "Yearly Statistics";
            this.Load += new System.EventHandler(this.YearlyStats_Load);
            ((System.ComponentModel.ISupportInitialize)(this.allTimeDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearlyDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView allTimeDataGrid;
        private System.Windows.Forms.DataGridView yearlyDataGrid;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}