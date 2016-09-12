using BudgetRegistry.Model;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.View
{
    public partial class ViewSpendings : Form
    {
        UserModel _user;
        Context context = new Context();
        //List<ViewedSpendingModel> list;
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
                dataGridView.Columns[3].Visible = false;
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Only showing His/Her spendings. Log in as admin to show all spendings.";
            }
            else
            {
                toolStripStatusLabel.Text = "Logged in as " + _user.UserName +
                " | Showing all spendings.";
            }
            monthUpDown.Value = DateTime.Now.Month;
            refreshList();

        }

        public void refresh()
        {
            if (!autoRefreshCheckBox.Checked) return;

            //list.Clear();
            refreshList();
            //dataGridView1.DataSource = list;
        }


        public void refreshList()
        {
            List<SpendingModel> spendingList;
            dataGridView.Rows.Clear();
            if (_user.UserName != "admin")
                spendingList = context.Spendings
                .Where(m => m.CreatedTime.Year == yearUpDown.Value 
                && m.CreatedTime.Month == monthUpDown.Value 
                && m.UserId == _user.Id).ToList();
            else
            {
                spendingList = context.Spendings
                .Where(m => m.CreatedTime.Year == yearUpDown.Value
                && m.CreatedTime.Month == monthUpDown.Value).ToList();
            }


            
            foreach (var item in spendingList)
            {
                var spendingItem = context.SpendingItems.Where(s => s.Id == item.SpendingItemId).FirstOrDefault();
                var category = context.Categroies.Where(c => c.Id == spendingItem.CategoryId).FirstOrDefault();
                var user = context.Users.Where(u => u.Id == item.UserId).FirstOrDefault();
                dataGridView.Rows.Add(item.Id, spendingItem.Name, category.Name, user.UserName, item.Value, item.CreatedTime);
                dataGridView.Refresh();

            }
        }

        private void refeshButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            refreshList();
            
        }

        private void exportSpendingsButton_Click(object sender, EventArgs e)
        {
            using (var save = new SaveFileDialog())
            {

                save.Filter = "CSV fajlok|*.csv";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    exportSpendingWorker.RunWorkerAsync(save.FileName);
                    exportSpendingsButton.Enabled = false;
                }

            }
        }

        private void exportSpendingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (var writer = new StreamWriter((string)e.Argument))
            {
                var csvConfig = new CsvConfiguration();
                csvConfig.Delimiter = ";";
                csvConfig.HasHeaderRecord = true;
                csvConfig.QuoteAllFields = true;
                var csvWriter = new CsvWriter(writer, csvConfig);
                List<CsvModel> list = new List<CsvModel>();
                //var spendingList = _myContext.Spendings.ToList();
                csvWriter.WriteHeader<CsvModel>();
                foreach (DataGridViewRow item in dataGridView.Rows)
                {
                   /* var spendingItem = _myContext.SpendingItems.Where(s => s.Id == item.SpendingItemId).FirstOrDefault();
                    var category = _myContext.Categroies.Where(c => c.Id == spendingItem.CategoryId).FirstOrDefault();*/
                    csvWriter.WriteRecord(new CsvModel
                    {
                        Id = (int)item.Cells[0].Value,
                        Name = (string)item.Cells[1].Value,
                        CategoryName = (string)item.Cells[2].Value,
                        Value = (int)item.Cells[4].Value,
                        CreatedDate = (DateTime)item.Cells[5].Value

                    });
                }
            }
        }

        private void exportSpendingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            exportSpendingsButton.Enabled = true;
        }
    }
}
