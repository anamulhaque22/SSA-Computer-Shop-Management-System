namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedDiscountAndTaskTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discounts", "Coupon", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Discounts", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Discounts", "ExpireTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Tasks", "Time", c => c.DateTime(nullable: false));
            DropColumn("dbo.Discounts", "Description");
            DropColumn("dbo.Discounts", "Time");
            DropColumn("dbo.Tasks", "Coupon");
            DropColumn("dbo.Tasks", "Amount");
            DropColumn("dbo.Tasks", "ExpireTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "ExpireTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Coupon", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Discounts", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discounts", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Tasks", "Time");
            DropColumn("dbo.Tasks", "Description");
            DropColumn("dbo.Discounts", "ExpireTime");
            DropColumn("dbo.Discounts", "Amount");
            DropColumn("dbo.Discounts", "Coupon");
        }
    }
}
