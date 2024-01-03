namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SoldCountAddedInProductTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "SoldCount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "SoldCount");
        }
    }
}
