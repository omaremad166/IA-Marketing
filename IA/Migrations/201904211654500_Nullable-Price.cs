namespace IA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullablePrice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Price", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "Price", c => c.Int(nullable: false));
        }
    }
}
