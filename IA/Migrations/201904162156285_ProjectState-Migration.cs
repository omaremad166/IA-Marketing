namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectStateMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectStates",
                c => new
                    {
                        ProjectStateId = c.Int(nullable: false, identity: true),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.ProjectStateId);
            
            AddColumn("dbo.Projects", "ProjectStateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ProjectStateId");
            AddForeignKey("dbo.Projects", "ProjectStateId", "dbo.ProjectStates", "ProjectStateId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectStateId", "dbo.ProjectStates");
            DropIndex("dbo.Projects", new[] { "ProjectStateId" });
            DropColumn("dbo.Projects", "ProjectStateId");
            DropTable("dbo.ProjectStates");
        }
    }
}
