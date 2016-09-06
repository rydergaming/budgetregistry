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
                dataGridView1.Columns[2].Visible = false;
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Only showing His/Her spendings. Log in as admin to show all spendings.";
            }
            else
            {
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Showing all spendings.";
            }
        }
    }
}
