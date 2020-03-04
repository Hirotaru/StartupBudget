namespace StartupBudget.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedNameRequirements : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Developers", "FirstName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Developers", "LastName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Developers", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Developers", "FirstName", c => c.String(nullable: false));
        }
    }
}
