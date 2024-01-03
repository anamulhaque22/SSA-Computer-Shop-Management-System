namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProfitAddedAndProductOrderDetailTableModified : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerProfits",
                c => new
                    {
                        CusId = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        TotalProfit = c.Int(nullable: false),
                        TempTotalProfit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CusId)
                .ForeignKey("dbo.Customers", t => t.CusId, cascadeDelete: true)
                .Index(t => t.CusId);
            
            AddColumn("dbo.OrderDetails", "UnitCostPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CostPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerProfits", "CusId", "dbo.Customers");
            DropIndex("dbo.CustomerProfits", new[] { "CusId" });
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.OrderDetails", "UnitCostPrice");
            DropTable("dbo.CustomerProfits");
        }
    }
}
