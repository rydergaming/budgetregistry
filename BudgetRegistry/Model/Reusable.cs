using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.Model
{
    public static class Reusable
    {
        static Context _myContext = new Context();
        public static CategoryModel CheckCategory(Context context, string name)
        {
            //Context context = new Context();
            return context.Categroies.Where(c => c.Name == name).FirstOrDefault();
        }

        public static SpendingItemModel CheckSpendingItem(Context context,string name)
        {
            //Context context = new Context();
            return context.SpendingItems.Where(c => c.Name == name).FirstOrDefault();
        }

        public static IncomeItemModel CheckIncomeItem(Context context, string name)
        {
            //Context context = new Context();
            return context.IncomeItems.Where(c => c.Name == name).FirstOrDefault();
        }

        public static Form GetForm(string formType)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.GetType() == Type.GetType(formType))
                {
                    return form;
                }
            }

            return null;
        }

        public static void TotalSpendingIncome(List<Stats> stats, IQueryable<SpendingModel> spendings, IQueryable<IncomeModel> incomes, bool isYear)
        {
            foreach (var item in stats)
            {
                foreach (var income in incomes)
                {
                    switch (isYear)
                    {
                        case true:
                            if (income.CreatedTime.Year == item.Id)
                                item.TotalIncome += income.Value;

                            break;
                        case false:
                            if (income.CreatedTime.Month == item.Id)
                                item.TotalIncome += income.Value;
                            break;
                    }
                }
                foreach (var spending in spendings)
                {
                    switch(isYear)
                    {
                        case true:
                            if (spending.CreatedTime.Year == item.Id)
                                item.TotalSpending += spending.Value;
                            
                            break;
                        case false:
                            if (spending.CreatedTime.Month == item.Id)
                                item.TotalSpending += spending.Value;
                            break;
                    }
                }
                item.Difference = item.TotalIncome - item.TotalSpending;

            }
        }

        public static BindingList<Stats> CategoryStats(List<SpendingModel> spendings, List<IncomeModel> incomes)
        {
            
            List<SpendingItemModel> spendingItems = new List<SpendingItemModel>();
            List<IncomeItemModel> incomeItems = new List<IncomeItemModel>();

            foreach (var item in spendings)
            {
                spendingItems.Add(_myContext.SpendingItems.Where(m => m.Id == item.SpendingItemId).FirstOrDefault());
            }
            foreach (var item in incomes)
            {
                incomeItems.Add(_myContext.IncomeItems.Where(m => m.Id == item.IncomeItemId).FirstOrDefault());
            }
            List<CategoryModel> categories = new List<CategoryModel>();

            foreach (var item in spendingItems)
            {
                categories.Add(_myContext.Categroies.Where(m => m.Id == item.CategoryId).FirstOrDefault());
            }
            foreach (var item in incomeItems)
            {
                categories.Add(_myContext.Categroies.Where(m => m.Id == item.CategoryId).FirstOrDefault());
            }
            categories = categories.Distinct().ToList();
            List<Stats> stats = new List<Stats>();
            foreach (var category in categories)
            {
                stats.Add(new Stats
                {
                    Id = category.Id,
                    Name = category.Name
                });
                var currentCategory = stats.Find(m => m.Id == category.Id);
                foreach (var categoryItems in spendingItems)
                {
                    var tmpSpendingModel = spendings
                        .Where(m =>
                        m.SpendingItemId == categoryItems.Id && categoryItems.CategoryId == category.Id)
                        .Select(m => m.Value).Sum();
                    currentCategory.TotalSpending += tmpSpendingModel;                    
                }
                foreach (var categoryItems in incomeItems)
                {
                    var tmpIncomeModel = incomes
                        .Where(m =>
                        m.IncomeItemId == categoryItems.Id && categoryItems.CategoryId == category.Id)
                        .Select(m => m.Value).Sum();
                    currentCategory.TotalIncome += tmpIncomeModel;
                }
                currentCategory.Difference = currentCategory.TotalIncome - currentCategory.TotalSpending;
            }
            return new BindingList<Stats>(stats);
        }

        public static void PercentStats(DataGridView dataGrid)
        {
            double totalSpending = 0;
            double totalIncome = 0;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                totalSpending += (long?)row.Cells[3].Value ?? 0;
                totalIncome += (long?)row.Cells[2].Value ?? 0;
            }
            if (totalSpending != 0)
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    var percent = (((long?)row.Cells[3].Value ?? 0) * 100D) / totalSpending;
                    percent = Math.Round(percent, 4);
                    row.Cells[6].Value = percent.ToString() + "%";
                }
            if (totalIncome != 0)
            {
                foreach (DataGridViewRow row in dataGrid.Rows)
                {
                    var percent = (((long?)row.Cells[2].Value ?? 0) * 100D) / totalIncome;
                    percent = Math.Round(percent, 4);
                    row.Cells[5].Value = percent.ToString() + "%";
                }
            }
        }
        
        public class Stats
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public long TotalIncome { get; set; }
            public long TotalSpending { get; set; }
            public long Difference { get; set; }
            public string IncomePercent { get; set; }
            public string SpendingPercent { get; set; }
            
        }
    }
}
