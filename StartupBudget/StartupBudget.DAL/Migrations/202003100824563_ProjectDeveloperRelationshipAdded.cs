namespace StartupBudget.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectDeveloperRelationshipAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Project_Developer",
                c => new
                    {
                        ProjectId = c.Int(nullable: false),
                        DeveloperId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProjectId, t.DeveloperId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Developers", t => t.DeveloperId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.DeveloperId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Project_Developer", "DeveloperId", "dbo.Developers");
            DropForeignKey("dbo.Project_Developer", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Project_Developer", new[] { "DeveloperId" });
            DropIndex("dbo.Project_Developer", new[] { "ProjectId" });
            DropTable("dbo.Project_Developer");
        }
    }
}
