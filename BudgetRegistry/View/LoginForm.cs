using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.View
{
    public partial class LoginForm : Form
    {
        Context _myContext = new Context();
        public UserModel user;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" || passwordTextBox.Text == "")
            {
                MessageBox.Show("Username/Password cannot be empty.");
                return;
            }
            user = Reusable.CheckUserModel(_myContext, usernameTextBox.Text);
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
            user = _myContext.Users.Where(u => u.UserName == usernameTextBox.Text)
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
                _myContext.Users.Add(newUser);
                _myContext.SaveChanges();
                user = newUser;
                MessageBox.Show("Successfully Registered " + user.UserName + ".\nLogging in.");
                DialogResult = DialogResult.OK;
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            DateTime lastModified = File.GetLastWriteTime("BudgetRegistry.exe");
            infoLabel.Text = "Budget Registry | Last Modified: " + lastModified.ToString("dd/MM/yy HH:mm:ss");
        }
    }
}
