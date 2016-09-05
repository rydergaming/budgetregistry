using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    public class SpendingModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SpendingItemId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
