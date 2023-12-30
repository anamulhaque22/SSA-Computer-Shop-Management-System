namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed_CustomerProfitAddedAndProductOrderDetailTableModified : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CustomerProfits", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerProfits", "Id", c => c.Int(nullable: false));
        }
    }
}
