using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BudgetRegistry.Model.Reusable;

namespace BudgetRegistry.View
{


    public partial class MonthlyStats : Form
    {
        UserModel _user;
        List<Stats> _stats;
        Context _myContext = new Context();
        IQueryable<SpendingModel> _yearlySpendings;
        public MonthlyStats()
        {
            InitializeComponent();
            resetMonthlyGrid();
        }

        private void MonthlyStats_Load(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
            _user = form.CurrentUser;
            _yearlySpendings = _myContext.Spendings.Where(m => m.CreatedTime.Year == (int)yearNumericUpDown.Value);
            Reusable.TotalSpendingIncome(_stats, _yearlySpendings,false);

            monthlyStatGrid.DataSource = _stats;
            monthlyStatGrid.Columns[1].Visible = false;
        }

        private void monthlyStatGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (monthlyStatGrid.CurrentRow == null) return;

            var monthlySpendings = _yearlySpendings.Where(m => m.CreatedTime.Month == monthlyStatGrid.CurrentRow.Index + 1).ToList();

            monthCategoryGrid.DataSource = (IBindingList)Reusable.CategoryStats(monthlySpendings);

        }

        private void yearNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            resetMonthlyGrid();
            _yearlySpendings = _myContext.Spendings.Where(m => m.CreatedTime.Year == (int)yearNumericUpDown.Value);
            Reusable.TotalSpendingIncome(_stats, _yearlySpendings,false);

            monthlyStatGrid.DataSource = _stats;
            monthlyStatGrid.Refresh();
        }
        private void resetMonthlyGrid()
        {
            _stats = new List<Stats>();
            for (int i = 1; i <= 12; i++)
            {
                _stats.Add(new Stats
                {
                    Id = i
                });
            }
        }
    }


}
