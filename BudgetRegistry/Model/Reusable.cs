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

        public static void TotalSpendingIncome(List<Stats> stats, IQueryable<SpendingModel> spendings, bool isYear)
        {
            foreach (var item in stats)
            {
                //Add income here
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

        public static BindingList<Stats> CategoryStats(List<SpendingModel> monthlySpendings)
        {
            
            List<SpendingItemModel> monthlySpendingItems = new List<SpendingItemModel>();

            foreach (var item in monthlySpendings)
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
            foreach (var category in monthlyCategories)
            {
                monthlyStats.Add(new Stats
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            foreach (var category in monthlyCategories)
            {
                var currentCategory = monthlyStats.Find(m => m.Id == category.Id);
                foreach (var categoryItems in monthlySpendingItems)
                {
                    var tmpSpendingModel = monthlySpendings
                        .Where(m =>
                        m.SpendingItemId == categoryItems.Id && categoryItems.CategoryId == category.Id)
                        .Select(m => m.Value).Sum();
                    currentCategory.TotalSpending += tmpSpendingModel;
                }
                currentCategory.Difference = currentCategory.TotalIncome - currentCategory.TotalSpending;
            }
            return new BindingList<Stats>(monthlyStats);
        }
        public static void PercentStats(DataGridView dataGrid)
        {
            double totalSpending = 0;
            foreach (DataGridViewRow row in dataGrid.Rows)
            {
                totalSpending += (int?)row.Cells[3].Value ?? 0;
            }
            if (totalSpending != 0)
                foreach (DataGridViewRow row in dataGrid.Rows)
                {

                    var percent = (((int?)row.Cells[3].Value ?? 0) * 100D) / totalSpending;
                    percent = Math.Round(percent, 4);
                    row.Cells[5].Value = percent.ToString() + "%";
                }
        }
        
        public class Stats
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int TotalIncome { get; set; }
            public int TotalSpending { get; set; }
            public int Difference { get; set; }
            public string SpendingPercent { get; set; }
            public string IncomePercent { get; set; }
        }
    }
}
