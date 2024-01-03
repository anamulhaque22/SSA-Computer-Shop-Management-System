namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TempTotalProfitFieldRemovedFromCustomerProfitTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerProfits", "TempTotalProfit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerProfits", "TempTotalProfit", c => c.Int(nullable: false));
        }
    }
}
