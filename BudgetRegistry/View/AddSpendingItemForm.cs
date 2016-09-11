using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.View
{
    public partial class AddSpendingItemForm : Form
    {
        List<String> nameList;
        List<String> categoryList;
        Context _myContext = new Context();
        public AddSpendingItemForm()
        {
            InitializeComponent();
            bindingSource.DataSource = _myContext.SpendingItems.ToList();
        }

        private void itemNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Context context = new Context();
            nameList = context.SpendingItems
                .Where(n => n.Name.Contains(itemNameTextBox.Text))
                .Select(s => s.Name).ToList();
            itemNameTextBox.AutoCompleteCustomSource.AddRange(nameList.ToArray());
        }

        private void itemCategoryTextBox_TextChanged(object sender, EventArgs e)
        {
            Context context = new Context();
            categoryList = context.Categroies
                .Where(n => n.Name.Contains(itemCategoryTextBox.Text))
                .Select(s => s.Name).ToList();
            itemCategoryTextBox.AutoCompleteCustomSource.AddRange(nameList.ToArray());
        }

        private void addItemButton_Click(object sender, EventArgs e)
        {
            if (itemCategoryTextBox.Text == "" || itemCategoryTextBox.Text == "")
            {
                MessageBox.Show("Item Name and Category cannot be empty!");
                return;
            }
            var name = Reusable.CheckSpendingItem(_myContext, itemNameTextBox.Text).Name;

            var category = Reusable.CheckCategory(_myContext, itemCategoryTextBox.Text);

            if (name != null)
            {
                if (MessageBox.Show("Item with this name already exists!\nDo you want to overwrite it with new Value/Category?","Warning!",MessageBoxButtons.YesNo) == DialogResult.Yes)
                {                    
                    if (category == null)
                    {
                        _myContext.Categroies.Add(new CategoryModel
                        {
                            Name = itemCategoryTextBox.Text
                        });

                        _myContext.SaveChanges();
                    }
                    category = Reusable.CheckCategory(_myContext, itemCategoryTextBox.Text);

                    var item = _myContext.SpendingItems.Where(i => i.Name == name).FirstOrDefault();
                        
                    item.LastValue = (int)numericUpDown.Value;
                    item.CategoryId = category.Id;
                    _myContext.SaveChanges();
                    DialogResult = DialogResult.OK;                    
                    this.Close();
                }

            }
            else
            {
                if (category == null)
                {
                    _myContext.Categroies.Add(new CategoryModel
                    {
                        Name = itemCategoryTextBox.Text
                    });

                    _myContext.SaveChanges();
                }
                category = Reusable.CheckCategory(_myContext, itemCategoryTextBox.Text);

                _myContext.SpendingItems.Add(
                    new SpendingItemModel
                    {
                        Name = itemNameTextBox.Text,
                        LastValue = (int)numericUpDown.Value,
                        CategoryId = category.Id
                    });
                _myContext.SaveChanges();
                DialogResult = DialogResult.OK;
                this.Close();
            }
            RefreshViewForm();
        }
        private void RefreshViewForm()
        {
            ViewSpendingItems form = (ViewSpendingItems)Reusable.GetForm("BudgetRegistry.View.ViewSpendingItems");
            if (form !=null)
                form.refresh();
        }
    }
}
