namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discounts", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Discounts", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Coupon", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.Tasks", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "ExpireTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Admins", "PictureName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Products", "ImageUrl");
            DropColumn("dbo.Products", "PublicImageId");
            DropColumn("dbo.Products", "SoldCount");
            DropColumn("dbo.OrderDetails", "UnitCostPrice");
            DropColumn("dbo.Discounts", "Coupon");
            DropColumn("dbo.Discounts", "Amount");
            DropColumn("dbo.Discounts", "ExpireTime");
            DropColumn("dbo.Tasks", "Description");
            DropColumn("dbo.Tasks", "Time");
            DropColumn("dbo.TotalRevenues", "Year");
            DropColumn("dbo.TotalSales", "Year");
            DropTable("dbo.AdminTokens");
            DropTable("dbo.CustomerProfits");
            DropTable("dbo.CustomerTokens");
            DropTable("dbo.Employees");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Name = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Nid = c.String(),
                        Password = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Address = c.String(),
                        Post = c.String(),
                        Salary = c.Int(nullable: false),
                        CurrentRating = c.Int(nullable: false),
                        PictureName = c.String(),
                        Otp = c.Int(nullable: false),
                        OtpVerified = c.Int(nullable: false),
                        AdminApproval = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerProfits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CusId = c.Int(nullable: false),
                        TotalProfit = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AdminTokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TotalSales", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.TotalRevenues", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Tasks", "Time", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Description", c => c.String(nullable: false));
            AddColumn("dbo.Discounts", "ExpireTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Discounts", "Amount", c => c.Int(nullable: false));
            AddColumn("dbo.Discounts", "Coupon", c => c.String(nullable: false, maxLength: 12));
            AddColumn("dbo.OrderDetails", "UnitCostPrice", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SoldCount", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "PublicImageId", c => c.String(nullable: false));
            AddColumn("dbo.Products", "ImageUrl", c => c.String(nullable: false));
            AlterColumn("dbo.OrderDetails", "UnitPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "CostPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "ProductPrice", c => c.Int(nullable: false));
            AlterColumn("dbo.Admins", "PictureName", c => c.String());
            DropColumn("dbo.Tasks", "ExpireTime");
            DropColumn("dbo.Tasks", "Amount");
            DropColumn("dbo.Tasks", "Coupon");
            DropColumn("dbo.Discounts", "Time");
            DropColumn("dbo.Discounts", "Description");
        }
    }
}
