namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProjectMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Price = c.Int(nullable: false),
                        Description = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "UserId", "dbo.Users");
            DropIndex("dbo.Projects", new[] { "UserId" });
            DropTable("dbo.Projects");
        }
    }
}
