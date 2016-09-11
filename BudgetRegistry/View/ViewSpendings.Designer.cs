namespace BudgetRegistry.View
{
    partial class ViewSpendings
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.autoRefreshCheckBox = new System.Windows.Forms.CheckBox();
            this.refeshButton = new System.Windows.Forms.Button();
            this.userModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.yearUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.monthUpDown = new System.Windows.Forms.NumericUpDown();
            this.viewedSpendingModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.exportSpendingsButton = new System.Windows.Forms.Button();
            this.exportSpendingWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewedSpendingModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Name,
            this.Category,
            this.UserName,
            this.Value,
            this.Date});
            this.dataGridView.Location = new System.Drawing.Point(0, 36);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(623, 256);
            this.dataGridView.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.HeaderText = "Item Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.HeaderText = "Date Added";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 276);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(623, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(77, 17);
            this.toolStripStatusLabel.Text = "Logged in as ";
            // 
            // autoRefreshCheckBox
            // 
            this.autoRefreshCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoRefreshCheckBox.AutoSize = true;
            this.autoRefreshCheckBox.Location = new System.Drawing.Point(238, 10);
            this.autoRefreshCheckBox.Name = "autoRefreshCheckBox";
            this.autoRefreshCheckBox.Size = new System.Drawing.Size(88, 17);
            this.autoRefreshCheckBox.TabIndex = 2;
            this.autoRefreshCheckBox.Text = "Auto Refresh";
            this.autoRefreshCheckBox.UseVisualStyleBackColor = true;
            // 
            // refeshButton
            // 
            this.refeshButton.Location = new System.Drawing.Point(332, 6);
            this.refeshButton.Name = "refeshButton";
            this.refeshButton.Size = new System.Drawing.Size(75, 23);
            this.refeshButton.TabIndex = 3;
            this.refeshButton.Text = "Refresh";
            this.refeshButton.UseVisualStyleBackColor = true;
            this.refeshButton.Click += new System.EventHandler(this.refeshButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Year";
            // 
            // yearUpDown
            // 
            this.yearUpDown.Location = new System.Drawing.Point(47, 9);
            this.yearUpDown.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.yearUpDown.Minimum = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.yearUpDown.Name = "yearUpDown";
            this.yearUpDown.Size = new System.Drawing.Size(66, 20);
            this.yearUpDown.TabIndex = 5;
            this.yearUpDown.Value = new decimal(new int[] {
            2016,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Month";
            // 
            // monthUpDown
            // 
            this.monthUpDown.Location = new System.Drawing.Point(162, 9);
            this.monthUpDown.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.monthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monthUpDown.Name = "monthUpDown";
            this.monthUpDown.Size = new System.Drawing.Size(54, 20);
            this.monthUpDown.TabIndex = 7;
            this.monthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // viewedSpendingModelBindingSource
            // 
            this.viewedSpendingModelBindingSource.DataSource = typeof(BudgetRegistry.Model.ViewedSpendingModel);
            // 
            // exportSpendingsButton
            // 
            this.exportSpendingsButton.Location = new System.Drawing.Point(507, 6);
            this.exportSpendingsButton.Name = "exportSpendingsButton";
            this.exportSpendingsButton.Size = new System.Drawing.Size(104, 23);
            this.exportSpendingsButton.TabIndex = 8;
            this.exportSpendingsButton.Text = "Export Spendings";
            this.exportSpendingsButton.UseVisualStyleBackColor = true;
            this.exportSpendingsButton.Click += new System.EventHandler(this.exportSpendingsButton_Click);
            // 
            // exportSpendingWorker
            // 
            this.exportSpendingWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.exportSpendingWorker_DoWork);
            // 
            // ViewSpendings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 298);
            this.Controls.Add(this.exportSpendingsButton);
            this.Controls.Add(this.monthUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.yearUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refeshButton);
            this.Controls.Add(this.autoRefreshCheckBox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dataGridView);
            //this.Name = "ViewSpendings";
            this.Text = "ViewSpendings";
            this.Load += new System.EventHandler(this.ViewSpendings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yearUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.monthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewedSpendingModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.BindingSource userModelBindingSource;
        private System.Windows.Forms.BindingSource viewedSpendingModelBindingSource;
        private System.Windows.Forms.CheckBox autoRefreshCheckBox;
        private System.Windows.Forms.Button refeshButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown yearUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown monthUpDown;
        private System.Windows.Forms.Button exportSpendingsButton;
        private System.ComponentModel.BackgroundWorker exportSpendingWorker;
    }
}