﻿using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static BudgetRegistry.Model.Reusable;

namespace BudgetRegistry.View
{
    public partial class YearlyStats : Form
    {
        UserModel _user;
        List<Stats> _stats;
        Context _myContext = new Context();
        IQueryable<SpendingModel> _allTimeSpendings;
        IQueryable<IncomeModel> _allTimeIncomes;
        public YearlyStats()
        {
            InitializeComponent();
            initStats();
        }

        private void initStats()
        {
            _stats = new List<Stats>();
            for (int i=1950; i<=2030; i++)
            {
                _stats.Add(new Stats
                {
                    Id = i
                });
            }
        }

        private void YearlyStats_Load(object sender, EventArgs e)
        {
            MainForm form = (MainForm)Reusable.GetForm("BudgetRegistry.MainForm");
            _user = form.CurrentUser;
            _allTimeSpendings = _myContext.Spendings;
            _allTimeIncomes = _myContext.Incomes;
            Reusable.TotalSpendingIncome(_stats, _allTimeSpendings, _allTimeIncomes, true);

            allTimeDataGrid.DataSource = _stats;
            allTimeDataGrid.Columns[1].Visible = false;
            allTimeDataGrid.Columns[5].Visible = false;
            allTimeDataGrid.Columns[6].Visible = false;
        }

        private void allTimeDataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (allTimeDataGrid.CurrentRow == null) return;
            int tmp = allTimeDataGrid.CurrentRow.Index + 1950;
            var monthlySpendings = _allTimeSpendings
                .Where(m => m.CreatedTime.Year == tmp).ToList();
            var monthlyIncomes = _allTimeIncomes
                .Where(m => m.CreatedTime.Year == tmp).ToList();

            yearlyDataGrid.DataSource = (IBindingList)Reusable.CategoryStats(_myContext, monthlySpendings, monthlyIncomes);

            Reusable.PercentStats(yearlyDataGrid);
        }
    }
}
