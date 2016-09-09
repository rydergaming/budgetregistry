using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    interface IContext
    {
        IDbSet<CategoryModel> Categroies { get; set; }
        IDbSet<IncomeItemModel> IncomeItems { get; set; }
        IDbSet<IncomeModel> Incomes { get; set; }
        IDbSet<SpendingItemModel> SpendingItems { get; set; }
        IDbSet<SpendingModel> Spendings { get; set; }
        IDbSet<UserModel> Users { get; set; }
    }
}
