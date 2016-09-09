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


    public partial class MonthlyStats : Form
    {
        UserModel _user;
        List<Stats> _stats = new List<Stats>();
        Context _myContext = new Context();
        List<SpendingModel> yearlySpendings;
        List<SpendingModel> monthlySpendings;
        public MonthlyStats()
        {
            InitializeComponent();
            for (int i=1; i<=12; i++)
            {
                _stats.Add(new Stats
                {
                    Id = i
                });
            }
        }

        private void MonthlyStats_Load(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
            _user = form.CurrentUser;
            yearlySpendings = _myContext.Spendings.Where(m => m.CreatedTime.Year == (int)yearNumericUpDown.Value).ToList();
            foreach(var item in _stats)
            {
                foreach(var spending in yearlySpendings)
                {
                    if (spending.CreatedTime.Month == item.Id)
                        item.TotalSpending += spending.Value;
                }

            }
            monthlyStatGrid.DataSource = _stats;
        }

        private void monthlyStatGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (monthlyStatGrid.CurrentRow == null) return;
            MessageBox.Show("I'm Here");
            yearlySpendings = _myContext.Spendings.Where(m => m.CreatedTime.Year == (int)yearNumericUpDown.Value).ToList();
            monthlySpendings = yearlySpendings.Where(m => m.CreatedTime.Month == monthlyStatGrid.CurrentRow.Index).ToList();
            monthCategoryGrid.DataSource = monthlySpendings;
            monthCategoryGrid.Refresh();
        }
    }

    class Stats
    {
        public int Id { get; set; }
        public int TotalIncome { get; set; }
        public int TotalSpending { get; set; }
        public int Difference { get; set; }
    }
}
