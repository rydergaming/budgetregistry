using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    public class ViewedSpendingModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string CategoryName { get; set; }
        public string UserName { get; set; }
        public long Value { get; set; }
        public DateTime AddTime { get; set; }
    }
}
