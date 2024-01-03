namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerProfitAndCustomerRelationshipRemoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerProfits", "CusId", "dbo.Customers");
            DropIndex("dbo.CustomerProfits", new[] { "CusId" });
            DropPrimaryKey("dbo.CustomerProfits");
            AddColumn("dbo.CustomerProfits", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CustomerProfits", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CustomerProfits");
            DropColumn("dbo.CustomerProfits", "Id");
            AddPrimaryKey("dbo.CustomerProfits", "CusId");
            CreateIndex("dbo.CustomerProfits", "CusId");
            AddForeignKey("dbo.CustomerProfits", "CusId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
