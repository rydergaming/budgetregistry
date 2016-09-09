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

namespace BudgetRegistry.View
{


    public partial class MonthlyStats : Form
    {
        UserModel _user;
        List<Stats> _stats = new List<Stats>();
        List<Stats> _categoryStats = new List<Stats>();
        Context _myContext = new Context();
        IQueryable<SpendingModel> _yearlySpendings;
        Context _yearlyContext;
        //List<SpendingModel> monthlySpendings;
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
            _yearlySpendings = _myContext.Spendings.Where(m => m.CreatedTime.Year == (int)yearNumericUpDown.Value);

            foreach(var item in _stats)
            {
                foreach(var spending in _yearlySpendings)
                {
                    if (spending.CreatedTime.Month == item.Id)
                        item.TotalSpending += spending.Value;
                }

            }
            monthlyStatGrid.DataSource = _stats;
            monthlyStatGrid.Columns[1].Visible = false;
        }

        private void monthlyStatGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (monthlyStatGrid.CurrentRow == null) return;

            var monthlySpendings = _yearlySpendings.Where(m => m.CreatedTime.Month == monthlyStatGrid.CurrentRow.Index+1).ToList();
            List<SpendingItemModel> monthlySpendingItems = new List<SpendingItemModel>();

            foreach(var item in monthlySpendings)
            {
                monthlySpendingItems.Add(_myContext.SpendingItems.Where(m => m.Id == item.SpendingItemId).FirstOrDefault());
            }
            List<CategoryModel> monthlyCategories = new List<CategoryModel>();

            foreach (var item in monthlySpendingItems)
            {
                monthlyCategories.Add(_myContext.Categroies.Where(m => m.Id == item.CategoryId).FirstOrDefault());
            }
            monthlyCategories = monthlyCategories.Distinct().ToList();
            List<Stats> monthlyStats = new List<Stats>();
            foreach(var category in monthlyCategories)
            {
                monthlyStats.Add(new Stats
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            foreach(var category in monthlyCategories)
            {
                Console.WriteLine(DateTime.Now.ToString());
                foreach (var categoryItems in monthlySpendingItems)
                {
                    SpendingModel tmpSpendingModel = monthlySpendings
                        .Where(m =>
                        m.SpendingItemId == categoryItems.Id && categoryItems.CategoryId == category.Id)
                        .FirstOrDefault();
                    if (tmpSpendingModel != null)
                        monthlyStats.Find(m => m.Id == category.Id).TotalSpending += tmpSpendingModel.Value;
                    
                }
                
            }

            monthCategoryGrid.DataSource = monthlyStats;
            monthCategoryGrid.Refresh();
        }
    }

    class Stats
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalIncome { get; set; }
        public int TotalSpending { get; set; }
        public int Difference { get; set; }
    }
}
