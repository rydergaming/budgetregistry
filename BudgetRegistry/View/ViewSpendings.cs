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
    public partial class ViewSpendings : Form
    {
        UserModel _user;
        Context context = new Context();
        List<ViewedSpendingModel> list;
        public ViewSpendings()
        {
            InitializeComponent();
        }

        private void ViewSpendings_Load(object sender, EventArgs e)
        {
            MainForm form = new MainForm();
            foreach(Form allForm in Application.OpenForms)
            {
                if (allForm.GetType() == typeof(MainForm))
                {
                    form = (MainForm)allForm;
                    break;
                }
            }
            _user = form.CurrentUser;
            if (_user.UserName != "admin")
            {
                dataGridView1.Columns[3].Visible = false;
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Only showing His/Her spendings. Log in as admin to show all spendings.";
            }
            else
            {
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Showing all spendings.";
            }
            refresh();

        }

        public void refresh()
        {
            if (!autoRefreshCheckBox.Checked) return;

            //list.Clear();
            refreshList();
            //dataGridView1.DataSource = list;
        }


        //Make this async pls
        private void refreshList()
        {
            var spendingList = context.Spendings.ToList();


            
            foreach (var item in spendingList)
            {
                var spendingItem = context.SpendingItems.Where(s => s.Id == item.SpendingItemId).FirstOrDefault();
                var category = context.Categroies.Where(c => c.Id == spendingItem.CategoryId).FirstOrDefault();
                var user = context.Users.Where(u => u.Id == item.UserId).FirstOrDefault();
                dataGridView1.Rows.Add(item.Id, spendingItem.Name, category.Name, user.UserName, item.Value, item.CreatedTime);
                dataGridView1.Refresh();

            }
        }

        private void refeshButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            refreshList();
            
        }
    }
}
