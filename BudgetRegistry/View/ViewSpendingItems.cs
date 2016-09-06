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
        
        public ViewSpendingItems()
        {
            InitializeComponent();
   
        }

        public void refresh()
        {
            spendingGrid.DataSource = Program._myContext.SpendingItems.ToList();
            
        }

        private void ViewSpendingItems_Load(object sender, EventArgs e)
        {
            spendingGrid.DataSource = Program._myContext.SpendingItems.ToList();
            spendingGrid.DataSource = spendingItemSource.DataSource;
        }
    }
}
