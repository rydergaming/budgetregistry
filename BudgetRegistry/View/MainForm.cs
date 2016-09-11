using Autofac;
using BudgetRegistry.Model;
using BudgetRegistry.View;
using CsvHelper;
using CsvHelper.Configuration;
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
        public UserModel CurrentUser;
        Context _myContext = new Context();
        List<Form> activeForms = new List<Form>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void addSpendingItem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("AddSpendingItemForm");
        }

        private void spendingItemsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("ViewSpendingItems");
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using (var lifeTimeScope = Program.container.BeginLifetimeScope())
            {
                var form = lifeTimeScope.Resolve<LoginForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CurrentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + CurrentUser.UserName;
                }
                else
                {
                    Application.Exit();
                }
            }
            OpenForm("ViewSpendingItems");
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
                    backgroundItemWorker.RunWorkerAsync(open.FileName);
                    loadSpendingItemButton.Enabled = false;
                }
                
            }
        }
        private void OpenForm(string openForm)
        {
            var lifeTimeScope = Program.container.BeginLifetimeScope();
            Form form = lifeTimeScope.ResolveNamed<Form>(openForm);
            foreach (Form sameForm in Application.OpenForms)
            {
                if (sameForm.GetType() == form.GetType())
                {
                    sameForm.Activate();
                    return;
                }
            }
            
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            form.Show();
            form.FormClosing += delegate
            {
                lifeTimeScope.Dispose();
            };
        }

        private void spendingButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("ViewSpendings");
        }

        private void addSpendingButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("AddSpending");
        }

        private void loadSpendingsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var open = new OpenFileDialog())
            {
                open.CheckFileExists = true;
                open.Multiselect = false;
                open.Filter = "CSV fajlok|*.csv";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    backgroundSpendingWorker.RunWorkerAsync(open.FileName);
                    loadSpendingsButton.Enabled = false;
                }

            }
        }

        private void backgroundItemWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var streamReader = new StreamReader((string)e.Argument, System.Text.Encoding.Default))
            {
                var csvConfig = new CsvConfiguration();
                csvConfig.Delimiter = ";";
                csvConfig.HasHeaderRecord = true;
                var reader = new CsvReader(streamReader,csvConfig);
                //reader.ReadHeader();
           
                while ( reader.Read() )
                {
                    Invoke(new Action(() => toolStripStatusLoad.Text = " | Line: " + reader.Row));
                    Invoke(new Action(() =>
                    {
                        ViewSpendingItems form = (ViewSpendingItems)Reusable.GetForm("BudgetRegistry.View.ViewSpendingItems");
                        if (form != null)
                            form.refresh();
                    }));
                    var item = reader.GetRecord<CsvModel>();
                    var category = Reusable.CheckCategory(_myContext, item.CategoryName);

                    if (category == null)
                    {
                        _myContext.Categroies.Add(new CategoryModel
                        {
                            Name = item.CategoryName
                        });

                        _myContext.SaveChanges();
                    }
                    category = Reusable.CheckCategory(_myContext, item.CategoryName);


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
                }
                
            }
        }

        private void backgroundItemWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadSpendingItemButton.Enabled = true;
        }

        private void backgroundSpendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var reader = new StreamReader((string)e.Argument, System.Text.Encoding.Default))
            {
                string line;
                int i = 0;
                reader.ReadLine();
                while (!reader.EndOfStream)
                {
                    i++;
                    Invoke(new Action(() => toolStripStatusLoadSpending.Text = " | Spending Line: " + i));
                    Invoke(new Action(() =>
                    {
                        ViewSpendings form = (ViewSpendings)Reusable.GetForm("BudgetRegistry.View.ViewSpendings");
                        if (form != null)
                            form.refresh();
                    }));
                    line = reader.ReadLine();
                    line = line.Replace("\"", "").Trim();
                    string[] elements = line.Split(';');
                    ViewedSpendingModel item = new ViewedSpendingModel
                    {
                        Id = Int32.Parse(elements[0]),
                        ItemName = elements[1],
                        CategoryName = elements[2],
                        Value = Int32.Parse(elements[3]),
                        AddTime = Convert.ToDateTime(elements[4])
                    };
                    var category = Reusable.CheckCategory(_myContext, item.CategoryName);

                    if (category == null)
                    {
                        _myContext.Categroies.Add(new CategoryModel
                        {
                            Name = item.CategoryName
                        });

                        _myContext.SaveChanges();
                    }
                    category = Reusable.CheckCategory(_myContext, item.CategoryName);


                    var spendItem = Reusable.CheckSpendingItem(_myContext, item.ItemName);
                    if (spendItem == null)
                    {
                        _myContext.SpendingItems.Add(new SpendingItemModel
                        {
                            CategoryId = category.Id,
                            LastValue = item.Value,
                            Name = item.ItemName
                        });
                        _myContext.SaveChanges();
                    }
                    else
                    {
                        spendItem.CategoryId = category.Id;
                        spendItem.LastValue = item.Value;
                        //spendItem.Name = item.Name;
                        _myContext.SaveChanges();

                    }
                    spendItem = Reusable.CheckSpendingItem(_myContext, item.ItemName);

                    _myContext.Spendings.Add(new SpendingModel
                    {
                        CreatedTime = item.AddTime,
                        SpendingItemId = spendItem.Id,
                        UserId = CurrentUser.Id,
                        Value = item.Value
                    });
                    _myContext.SaveChanges();
                }

            }
        }

        private void backgroundSpendingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            loadSpendingsButton.Enabled = true;
        }

        private void monthlyStatsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("MonthlyStats");
        }

        private void yearlyStatsButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm("YearlyStats");
        }

        private void loginButton_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var lifeTimeScope = Program.container.BeginLifetimeScope())
            {
                var form = lifeTimeScope.Resolve<LoginForm>();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    CurrentUser = form.user;
                    toolStripStatusLabel.Text = "Logged in as " + CurrentUser.UserName;
                    for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
                    {
                        if (Application.OpenForms[i].GetType() != typeof(MainForm))
                            Application.OpenForms[i].Close();
                    }
                }
            }
        }

        private void exportAllSpending_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (var save = new SaveFileDialog())
            {
            
                save.Filter = "CSV fajlok|*.csv";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    backgroundExportWorker.RunWorkerAsync(save.FileName);
                    exportAllSpending.Enabled = false;
                }

            }            
        }

        private void backgroundExportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var writer = new StreamWriter((string)e.Argument))
            {
                var csvConfig = new CsvConfiguration();
                csvConfig.Delimiter = ";";
                csvConfig.HasHeaderRecord = true;
                csvConfig.QuoteAllFields = true;
                var csvWriter = new CsvWriter(writer,csvConfig);
                List<CsvModel> list = new List<CsvModel>();
                var spendingList = _myContext.Spendings.ToList();
                csvWriter.WriteHeader<CsvModel>();
                foreach (var item in spendingList)
                {
                    var spendingItem = _myContext.SpendingItems.Where(s => s.Id == item.SpendingItemId).FirstOrDefault();
                    var category = _myContext.Categroies.Where(c => c.Id == spendingItem.CategoryId).FirstOrDefault();
                    csvWriter.WriteRecord(new CsvModel
                    {
                        Id = item.Id,
                        Name = spendingItem.Name,
                        CategoryName = category.Name,
                        Value = item.Value,
                        CreatedDate = item.CreatedTime
                    });
                }
            }

        }

        private void backgroundExportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportAllSpending.Enabled = true;
        }
    }
}
