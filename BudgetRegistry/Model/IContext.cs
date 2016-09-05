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
        IDbSet<CategoryModel> Categroies { get; }
        IDbSet<IncomeItemModel> IncomeItems { get; }
        IDbSet<IncomeModel> Incomes { get; }
        IDbSet<SpendingItemModel> SpendingItems { get; }
        IDbSet<SpendingModel> Spendings { get; }
        IDbSet<UserModel> Users { get; }
    }
}
