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
    public partial class LoginForm : Form
    {
        Context myContext = new BudgetRegistry.Model.Context();
        public UserModel user;
        public LoginForm()
        {
            InitializeComponent();
            //users = (BindingList<UserModel>) bindingSource.DataSource;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Username/Password cannot be empty.");
                return;
            }
            var password = Password.EncryptPassword(passwordTextBox.Text);
            user = myContext.Users.Where(u => u.UserName == usernameTextBox.Text)
                .FirstOrDefault();
            if (user == null)
            {
                MessageBox.Show("Wrong username/password.");
                return;
            }
            if (Password.CheckPassword(passwordTextBox.Text, user.Password))
            {
                MessageBox.Show("Successfully Logged in as " + user.UserName + "!");
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Wrong username/password.");
            }
           
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Username/Password cannot be empty.");
                return;
            }
            var password = Password.EncryptPassword(passwordTextBox.Text);
            user = myContext.Users.Where(u => u.UserName == usernameTextBox.Text)
                .FirstOrDefault();

            if (user != null)
            {
                MessageBox.Show("Username already exists!");
                return;
            }
            else
            {
                var newUser = new UserModel
                {
                    UserName = usernameTextBox.Text,
                    Password = Password.EncryptPassword(passwordTextBox.Text)
                };
                myContext.Users.Add(newUser);
                myContext.SaveChanges();
                user = newUser;
                DialogResult = DialogResult.OK;
            }
        }
    }
}
