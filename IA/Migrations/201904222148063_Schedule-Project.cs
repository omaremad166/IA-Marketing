namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ScheduleProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "StartDate", c => c.DateTime());
            AddColumn("dbo.Projects", "EndDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "EndDate");
            DropColumn("dbo.Projects", "StartDate");
        }
    }
}
