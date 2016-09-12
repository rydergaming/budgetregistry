namespace BudgetRegistry.View
{
    partial class AddIncome
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
            this.incomeNameTextBox = new System.Windows.Forms.TextBox();
            this.categoryTextBox = new System.Windows.Forms.TextBox();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.addIncomeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // incomeNameTextBox
            // 
            this.incomeNameTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.incomeNameTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.incomeNameTextBox.Location = new System.Drawing.Point(189, 12);
            this.incomeNameTextBox.Name = "incomeNameTextBox";
            this.incomeNameTextBox.Size = new System.Drawing.Size(264, 20);
            this.incomeNameTextBox.TabIndex = 0;
            // 
            // categoryTextBox
            // 
            this.categoryTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.categoryTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.categoryTextBox.Location = new System.Drawing.Point(189, 56);
            this.categoryTextBox.Name = "categoryTextBox";
            this.categoryTextBox.Size = new System.Drawing.Size(264, 20);
            this.categoryTextBox.TabIndex = 1;
            // 
            // numericUpDown
            // 
            this.numericUpDown.Location = new System.Drawing.Point(189, 100);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(264, 20);
            this.numericUpDown.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker.Location = new System.Drawing.Point(189, 144);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(264, 20);
            this.dateTimePicker.TabIndex = 3;
            // 
            // addIncomeButton
            // 
            this.addIncomeButton.Location = new System.Drawing.Point(292, 210);
            this.addIncomeButton.Name = "addIncomeButton";
            this.addIncomeButton.Size = new System.Drawing.Size(75, 23);
            this.addIncomeButton.TabIndex = 4;
            this.addIncomeButton.Text = "Add Income";
            this.addIncomeButton.UseVisualStyleBackColor = true;
            this.addIncomeButton.Click += new System.EventHandler(this.addIncomeButton_Click);
            // 
            // AddIncome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 245);
            this.Controls.Add(this.addIncomeButton);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.categoryTextBox);
            this.Controls.Add(this.incomeNameTextBox);
            this.Name = "AddIncome";
            this.Text = "AddIncome";
            this.Load += new System.EventHandler(this.AddIncome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox incomeNameTextBox;
        private System.Windows.Forms.TextBox categoryTextBox;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Button addIncomeButton;
    }
}