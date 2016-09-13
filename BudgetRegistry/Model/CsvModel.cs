using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetRegistry.Model
{
    class CsvModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public long Value { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    class CsVModelDateless
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public long Value { get; set; }
    }
}
