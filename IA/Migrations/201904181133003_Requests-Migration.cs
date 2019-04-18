namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestsMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "UserId" });
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        SenderId = c.Int(),
                        ReceiverId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .ForeignKey("dbo.Users", t => t.ReceiverId)
                .ForeignKey("dbo.Users", t => t.SenderId)
                .Index(t => t.ProjectId)
                .Index(t => t.SenderId)
                .Index(t => t.ReceiverId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.UserProjects",
                c => new
                    {
                        User_UserId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserId, t.Project_ProjectId })
                .ForeignKey("dbo.Users", t => t.User_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.User_UserId)
                .Index(t => t.Project_ProjectId);
            
            DropColumn("dbo.Projects", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Requests", "SenderId", "dbo.Users");
            DropForeignKey("dbo.Requests", "ReceiverId", "dbo.Users");
            DropForeignKey("dbo.Requests", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.UserProjects", "Project_ProjectId", "dbo.Projects");
            DropForeignKey("dbo.UserProjects", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Requests", "ProjectId", "dbo.Projects");
            DropIndex("dbo.UserProjects", new[] { "Project_ProjectId" });
            DropIndex("dbo.UserProjects", new[] { "User_UserId" });
            DropIndex("dbo.Requests", new[] { "User_UserId" });
            DropIndex("dbo.Requests", new[] { "ReceiverId" });
            DropIndex("dbo.Requests", new[] { "SenderId" });
            DropIndex("dbo.Requests", new[] { "ProjectId" });
            DropTable("dbo.UserProjects");
            DropTable("dbo.Requests");
            CreateIndex("dbo.Projects", "UserId");
            AddForeignKey("dbo.Projects", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
