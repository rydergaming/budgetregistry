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
    public partial class AddIncome : Form
    {
        Context _myContext = new Context();
        UserModel _user;
        public AddIncome()
        {
            InitializeComponent();
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
            _user = form.CurrentUser;
            numericUpDown.Maximum = Int32.MaxValue;
        }

        private void addIncomeButton_Click(object sender, EventArgs e)
        {
            if (incomeNameTextBox.Text == "")
            {
                MessageBox.Show("Income name cannot be empty!");
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

            var incomeItem = Reusable.CheckIncomeItem(_myContext, incomeNameTextBox.Text);
            if (incomeItem == null)
            {
                _myContext.IncomeItems.Add(new IncomeItemModel
                {
                    CategoryId = category.Id,
                    Name = incomeNameTextBox.Text,
                    LastValue = (int)numericUpDown.Value
                    
                });
                _myContext.SaveChanges();
            }
            else
            {
                //var item = _myContext.SpendingItems.Where(s => s.Name == spendingNameTextBox.Text).FirstOrDefault();
                incomeItem.LastValue = (int)numericUpDown.Value;
                _myContext.SaveChanges();
            }
            incomeItem = Reusable.CheckIncomeItem(_myContext, incomeNameTextBox.Text);

            _myContext.Incomes.Add(new IncomeModel
            {
                CreatedTime = dateTimePicker.Value,
                IncomeItemId = incomeItem.Id,
                UserId = _user.Id,
                Value = (int)numericUpDown.Value
            });
            _myContext.SaveChanges();
            MessageBox.Show("Income successfully saved!");
            incomeNameTextBox.Text = "";
            categoryTextBox.Text = "";
            numericUpDown.Value = 0;
            ViewSpendings form = (ViewSpendings)Reusable.GetForm("BudgetRegistry.View.ViewSpendings");
            if (form != null)
                form.refresh();

        }

        private void AddIncome_Load(object sender, EventArgs e)
        {
            incomeNameTextBox.AutoCompleteCustomSource.AddRange(_myContext.IncomeItems.Select(m => m.Name).ToArray());
            categoryTextBox.AutoCompleteCustomSource.AddRange(_myContext.Categroies.Select(m => m.Name).ToArray());
        }
    }
}
