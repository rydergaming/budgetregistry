using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    public class IncomeModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IncomeItemId { get; set; }
        public int Value { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
