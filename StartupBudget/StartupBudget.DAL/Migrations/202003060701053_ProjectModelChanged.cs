namespace StartupBudget.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Till", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.Projects", "From", c => c.DateTime(nullable: false, storeType: "date"));
            DropColumn("dbo.Projects", "To");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "From", c => c.DateTime(nullable: false));
            DropColumn("dbo.Projects", "Till");
        }
    }
}
