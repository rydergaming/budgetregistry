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
            spendingItem = Reusable.CheckSpendingItem(spendingNameTextBox.Text);

            context.Spendings.Add( new SpendingModel
            {
                CreatedTime = dateTimePicker.Value,
                SpendingItemId = spendingItem.Id,
                UserId = _user.Id
            });
            context.SaveChanges();
            MessageBox.Show("Spending successfully saved");

        }
    }
}
