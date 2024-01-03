namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderStatus", c => c.String());
            AddColumn("dbo.Orders", "PaymentStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentStatus");
            DropColumn("dbo.Orders", "OrderStatus");
        }
    }
}
