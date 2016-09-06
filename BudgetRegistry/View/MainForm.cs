﻿using Autofac;
using BudgetRegistry.Model;
using BudgetRegistry.View;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BudgetRegistry
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        UserModel _currentUser;
        Context _myContext = new Context();
        List<Form> activeForms = new List<Form>();
        public MainForm()
        {
            InitializeComponent();
            var lifeTimeScope = Program.container.BeginLifetimeScope();
            Form form = lifeTimeScope.Resolve<ViewSpendingItems>();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            activeForms.Add(form);
            form.FormClosed += delegate
            {
                activeForms.Remove(form);
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
                    _currentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + _currentUser.UserName;
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
                    _currentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + _currentUser.UserName;
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
            using (var open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "CSV fajlok|*.csv";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    backgroundWorker.RunWorkerAsync(open.FileName);
                    loadSpendingItemButton.Enabled = false;
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            
            using (var reader = new StreamReader((string)e.Argument, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    i++;
                    Invoke(new Action(() => toolStripStatusLoad.Text = "Line: " + i));
                    Invoke(new Action(() =>
                    {
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form.GetType() == typeof(ViewSpendingItems))
                            {
                                ViewSpendingItems viewForm = (ViewSpendingItems)form;
                                viewForm.refresh();
                            }
                        };
                    }));
                    line = reader.ReadLine();
                    line = line.Replace("\"", "").Trim();
                    string[] elements = line.Split(';');
                    CsvModel item = new CsvModel
                    {
                        Id = Int32.Parse(elements[0]),
                        Name = elements[1],
                        CategoryName = elements[2],
                        Value = Int32.Parse(elements[3])
                    };
                    var category = _myContext.Categroies.Where(c => c.Name == item.CategoryName).FirstOrDefault();

                    if (category == null)
                    {
                        _myContext.Categroies.Add(new CategoryModel
                        {
                            Name = item.CategoryName
                        });
                        
                        _myContext.SaveChanges();
                    }
                    category = _myContext.Categroies.Where(c => c.Name == item.CategoryName).FirstOrDefault();


                    var spendItem = _myContext.SpendingItems.Where(s => s.Id == item.Id).FirstOrDefault();
                    if (spendItem == null)
                    {
                        _myContext.SpendingItems.Add(new SpendingItemModel
                        {
                            CategoryId = category.Id,
                            LastValue = item.Value,
                            Name = item.Name
                        });
                        _myContext.SaveChanges();
                    }
                    else
                    {
                        spendItem.CategoryId = category.Id;
                        spendItem.LastValue = item.Value;
                        spendItem.Name = item.Name;
                        _myContext.SaveChanges();
                        
                    }


                    
                    /*Invoke(new Action(() =>
                    {
                        _items.Add(item);
                    }));*/
                }
                loadSpendingItemButton.Enabled = true;
            }
        }
    }
}
