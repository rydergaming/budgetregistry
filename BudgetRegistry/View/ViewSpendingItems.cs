using BudgetRegistry.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetRegistry.View
{

    public partial class ViewSpendingItems : Form
    {
        Context context = new Context();
        public ViewSpendingItems()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            spendingGrid.DataSource = context.SpendingItems.ToList();
            
        }

        private void ViewSpendingItems_Load(object sender, EventArgs e)
        {
            spendingGrid.DataSource = context.SpendingItems.ToList();
            //spendingGrid.DataSource = spendingItemSource.DataSource;
        }
    }
}
