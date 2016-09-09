using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    public class Context : DbContext, IContext
    {
        public Context() : this("BudgetRegistry")
            {
            }
        public Context(string connectionString) : base(connectionString)
        {
        }
        public IDbSet<CategoryModel> Categroies {
            get
            {
                return Set<CategoryModel>();
            }
            set { }
        }
        public IDbSet<IncomeItemModel> IncomeItems
        {
            get
            {
                return Set<IncomeItemModel>();
            }
            set { }
        }
        public IDbSet<IncomeModel> Incomes
        {
            get
            {
                return Set<IncomeModel>();
            }
            set { }
        }
        public IDbSet<SpendingItemModel> SpendingItems
        {
            get
            {
                return Set<SpendingItemModel>();
            }
            set { }
        }
        public IDbSet<SpendingModel> Spendings
        {
            get
            {
                return Set<SpendingModel>();
            }
            set { }
        }
        public IDbSet<UserModel> Users
        {
            get
            {
                return Set<UserModel>();
            }
            set { }
        }
    }
}
