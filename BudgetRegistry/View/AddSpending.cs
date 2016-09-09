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
        Context context = new Context();
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
            var category = Reusable.CheckCategory(categoryTextBox.Text);
            if (category == null)
            {
                context.Categroies.Add(new CategoryModel
                {
                    Name = categoryTextBox.Text
                });
                context.SaveChanges();
            }
            category = Reusable.CheckCategory(categoryTextBox.Text);

            var spendingItem = Reusable.CheckSpendingItem(spendingNameTextBox.Text);
            if (spendingItem == null)
            {
                context.SpendingItems.Add(new SpendingItemModel
                {
                    CategoryId = category.Id,
                    Name = spendingNameTextBox.Text,
                    LastValue = (int)numericUpDown.Value
                });
                context.SaveChanges();
            }
            else
            {
                var item = context.SpendingItems.Where(s => s.Name == spendingNameTextBox.Text).FirstOrDefault();
                item.LastValue = (int)numericUpDown.Value;
                context.SaveChanges();
            }
            spendingItem = Reusable.CheckSpendingItem(spendingNameTextBox.Text);

            context.Spendings.Add( new SpendingModel
            {
                CreatedTime = dateTimePicker.Value,
                SpendingItemId = spendingItem.Id,
                UserId = _user.Id,
                Value = (int)numericUpDown.Value
            });
            context.SaveChanges();
            MessageBox.Show("Spending successfully saved!");
            ViewSpendings form = (ViewSpendings)Reusable.GetForm("BudgetRegistry.View.ViewSpendings");
            form.refresh();
            this.Close();

        }

        private void spendingNameTextBox_TextChanged(object sender, EventArgs e)
        {
            nameList = context.SpendingItems
                .Where(n => n.Name.Contains(spendingNameTextBox.Text))
                .Select(s => s.Name).ToList();
            spendingNameTextBox.AutoCompleteCustomSource.AddRange(nameList.ToArray());
            var item = context.SpendingItems.Where(n => n.Name == spendingNameTextBox.Text).FirstOrDefault();
            if (item != null)
                numericUpDown.Value = item.LastValue;
        }

        private void categoryTextBox_TextChanged(object sender, EventArgs e)
        {
            categoryList = context.SpendingItems
                .Where(n => n.Name.Contains(categoryTextBox.Text))
                .Select(s => s.Name).ToList();
            categoryTextBox.AutoCompleteCustomSource.AddRange(categoryList.ToArray());
        }
    }
}
