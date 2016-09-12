namespace BudgetRegistry.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.IncomeItemModels", "LastValue", c => c.Long(nullable: false));
            AlterColumn("dbo.IncomeModels", "Value", c => c.Long(nullable: false));
            AlterColumn("dbo.SpendingItemModels", "LastValue", c => c.Long(nullable: false));
            AlterColumn("dbo.SpendingModels", "Value", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SpendingModels", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.SpendingItemModels", "LastValue", c => c.Int(nullable: false));
            AlterColumn("dbo.IncomeModels", "Value", c => c.Int(nullable: false));
            AlterColumn("dbo.IncomeItemModels", "LastValue", c => c.Int(nullable: false));
        }
    }
}
