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
        List<String> nameList = new List<string>();
        List<String> categoryList = new List<string>();

        public AddSpending()
        {
            InitializeComponent();
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
            _user = form.CurrentUser;

        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (spendingNameTextBox.Text == "")
            {
                MessageBox.Show("Spending Name Cannot be empty!");
                return;
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
                var item = _myContext.SpendingItems.Where(s => s.Name == spendingNameTextBox.Text).FirstOrDefault();
                item.LastValue = (int)numericUpDown.Value;
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
                form.refresh();


        }

        private void spendingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameList = _myContext.SpendingItems
                .Where(n => n.Name.Contains(spendingNameTextBox.Text))
                .Select(s => s.Name).ToList();
            spendingNameTextBox.AutoCompleteCustomSource.AddRange(nameList.ToArray());
            var item = _myContext.SpendingItems.Where(n => n.Name == spendingNameTextBox.Text).FirstOrDefault();
            if (item != null)
                numericUpDown.Value = item.LastValue;
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            categoryList = _myContext.SpendingItems
                .Where(n => n.Name.Contains(categoryTextBox.Text))
                .Select(s => s.Name).ToList();
            categoryTextBox.AutoCompleteCustomSource.AddRange(categoryList.ToArray());
        }
    }
}
