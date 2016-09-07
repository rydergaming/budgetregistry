using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.Model
{
    public static class Reusable
    {      

        public static CategoryModel CheckCategory(string name)
        {
            Context context = new Context();
            return context.Categroies.Where(c => c.Name == name).FirstOrDefault();
        }

        public static SpendingItemModel CheckSpendingItem(string name)
        {
            Context context = new Context();
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
    }
}
