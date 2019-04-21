namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyManyToManyRelationship : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.ProjectId })
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Project_ProjectId });
            
            DropForeignKey("dbo.UserProjects", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "UserId" });
            DropTable("dbo.UserProjects");
            CreateIndex("dbo.UserProjects", "Project_ProjectId");
            CreateIndex("dbo.UserProjects", "User_UserId");
            AddForeignKey("dbo.UserProjects", "Project_ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            AddForeignKey("dbo.UserProjects", "User_UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
