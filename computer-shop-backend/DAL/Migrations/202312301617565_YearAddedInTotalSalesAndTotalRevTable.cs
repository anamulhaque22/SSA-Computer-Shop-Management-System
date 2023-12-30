namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YearAddedInTotalSalesAndTotalRevTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TotalRevenues", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.TotalSales", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TotalSales", "Year");
            DropColumn("dbo.TotalRevenues", "Year");
        }
    }
}
