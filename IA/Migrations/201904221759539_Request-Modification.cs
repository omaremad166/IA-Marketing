namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModification : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "User_UserId", "dbo.Users");
            DropIndex("dbo.Requests", new[] { "User_UserId" });
            DropColumn("dbo.Requests", "User_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "User_UserId", c => c.Int());
            CreateIndex("dbo.Requests", "User_UserId");
            AddForeignKey("dbo.Requests", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
