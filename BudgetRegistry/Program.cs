using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Autofac;
using BudgetRegistry.View;
using BudgetRegistry.Model;

namespace BudgetRegistry
{
    static class Program
    {
        public static IContainer container;
        //public static Context _myContext = new Context();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MainForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<ViewSpendingItems>().Named<Form>("ViewSpendingItems").InstancePerLifetimeScope();
            builder.RegisterType<ViewSpendings>().Named<Form>("ViewSpendings").InstancePerLifetimeScope();
            builder.RegisterType<AddSpendingItemForm>().Named<Form>("AddSpendingItemForm").InstancePerLifetimeScope();
            builder.RegisterType<AddSpending>().Named<Form>("AddSpending").InstancePerLifetimeScope();
            builder.RegisterType<MonthlyStats>().Named<Form>("MonthlyStats").InstancePerLifetimeScope();
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();

            container = builder.Build();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(container.BeginLifetimeScope().Resolve<MainForm>());
        }
    }
}
