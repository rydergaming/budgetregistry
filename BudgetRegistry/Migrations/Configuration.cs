namespace BudgetRegistry.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BudgetRegistry.Model.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BudgetRegistry.Model.Context context)
        {

            context.Categroies.AddOrUpdate(
                c => c.Name,
                new Model.CategoryModel { Name = "Default" });
            context.Users.AddOrUpdate(
                u => u.UserName,
                new Model.UserModel
                    {   UserName = "admin",
                        Password = Model.Password.EncryptPassword("admin")
                    });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
