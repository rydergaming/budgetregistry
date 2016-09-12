using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.View
{
    public partial class AddSpending : Form
    {
        Context _myContext = new Context();
        UserModel _user;

        public AddSpending()
        {
            InitializeComponent();
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
                _user = form.CurrentUser;
            numericUpDown.Maximum = Int32.MaxValue;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (spendingNameTextBox.Text == "")
            {
                MessageBox.Show("Spending Name cannot be empty!");
                return;
            }
            if (categoryTextBox.Text == "")
            {
                MessageBox.Show("Category name is empty. Using default category.");
                categoryTextBox.Text = "Default";
            }
            
            var category = Reusable.CheckCategory(_myContext, categoryTextBox.Text);
            if (category == null)
            {
                _myContext.Categroies.Add(new CategoryModel
                {
                    Name = categoryTextBox.Text
                });
                _myContext.SaveChanges();
            }
            category = Reusable.CheckCategory(_myContext, categoryTextBox.Text);

            var spendingItem = Reusable.CheckSpendingItem(_myContext, spendingNameTextBox.Text);
            if (spendingItem == null)
            {
                _myContext.SpendingItems.Add(new SpendingItemModel
                {
                    CategoryId = category.Id,
                    Name = spendingNameTextBox.Text,
                    LastValue = (int)numericUpDown.Value
                });
                _myContext.SaveChanges();
            }
            else
            {
                //var item = _myContext.SpendingItems.Where(s => s.Name == spendingNameTextBox.Text).FirstOrDefault();
                spendingItem.LastValue = (int)numericUpDown.Value;
                _myContext.SaveChanges();
            }
            spendingItem = Reusable.CheckSpendingItem(_myContext, spendingNameTextBox.Text);

            _myContext.Spendings.Add( new SpendingModel
            {
                CreatedTime = dateTimePicker.Value,
                SpendingItemId = spendingItem.Id,
                UserId = _user.Id,
                Value = (int)numericUpDown.Value
            });
            _myContext.SaveChanges();
            MessageBox.Show("Spending successfully saved!");
            spendingNameTextBox.Text = "";
            categoryTextBox.Text = "";
            numericUpDown.Value = 0;
            ViewSpendings form = (ViewSpendings)Reusable.GetForm("BudgetRegistry.View.ViewSpendings");
            if (form != null)
                form.refreshList();
            else
                MessageBox.Show("Form was null");


        }

        private void spendingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            
            var text = spendingNameTextBox.Text;
            var item = _myContext.SpendingItems.Where(n => n.Name == text).FirstOrDefault();
            if (item != null)
                numericUpDown.Value = item.LastValue;
        }

        private void AddSpending_Load(object sender, EventArgs e)
        {
            spendingNameTextBox.AutoCompleteCustomSource.AddRange(_myContext.SpendingItems.Select(m => m.Name).ToArray());
            categoryTextBox.AutoCompleteCustomSource.AddRange(_myContext.Categroies.Select(m => m.Name).ToArray());
        }

        private void CanceButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
