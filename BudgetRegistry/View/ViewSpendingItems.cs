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
        Context _myContext = new Context();
        List<SpendingItemModel> list = new List<SpendingItemModel>();

        public ViewSpendingItems()
        {
            InitializeComponent();
            spendingItemSource.DataSource = _myContext.SpendingItems.ToList();
            spendingGrid.DataSource = spendingItemSource.DataSource;

        }

        public void refresh()
        {
            //spendingItemSource.DataSource = _myContext.SpendingItems.ToList();
            list = _myContext.SpendingItems.ToList();
            spendingGrid.DataSource = list;
            
        }

        private void ViewSpendingItems_Load(object sender, EventArgs e)
        {
            spendingGrid.DataSource = spendingItemSource.DataSource;
        }
    }
}
