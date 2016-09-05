using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using Autofac;
using BudgetRegistry.View;

namespace BudgetRegistry
{
    static class Program
    {
        public static IContainer container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MainForm>().AsSelf().InstancePerDependency();
            builder.RegisterType<ViewSpendingItems>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AddSpendingForm>().AsSelf().InstancePerLifetimeScope();
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
