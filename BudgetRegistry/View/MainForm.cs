using Autofac;
using BudgetRegistry.Model;
using BudgetRegistry.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetRegistry
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UserModel currentUser;
        public MainForm()
        {
            InitializeComponent();
            var lifeTimeScope = Program.container.BeginLifetimeScope();
            Form form = lifeTimeScope.Resolve<ViewSpendingItems>();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosed += delegate
            {
            };
        }

        private void addSpendingItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var lifeTimeScope = Program.container.BeginLifetimeScope();
            Form form = lifeTimeScope.Resolve<AddSpendingForm>();
            foreach (Form sameForm in Application.OpenForms)
            {
                if (sameForm.GetType() == typeof(AddSpendingForm))
                {
                    sameForm.Activate();
                    return;
                }
            }
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosed += delegate
            {

            };
        }

        private void spendingItemsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var lifeTimeScope = Program.container.BeginLifetimeScope())
            {
                var form = lifeTimeScope.Resolve<LoginForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + currentUser.UserName;
                }
                else
                {
                    Close();
                }
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var lifeTimeScope = Program.container.BeginLifetimeScope())
            {
                var form = lifeTimeScope.Resolve<LoginForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    currentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + currentUser.UserName;
                    for (int i = 0; i < Application.OpenForms.Count - 1; i++)
                    {
                        if (Application.OpenForms[i].GetType() != typeof(MainForm))
                            Application.OpenForms[i].Close();
                    }
                }
                else
                {

                }
            }

        }

        private void loadSpendingItemButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
    }
}
