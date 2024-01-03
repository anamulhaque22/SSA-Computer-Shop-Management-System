namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminOTPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Otp = c.String(),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 16),
                        OtpVerified = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 148),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 6),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nid = c.String(nullable: false, maxLength: 15),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false, maxLength: 100),
                        PictureName = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
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
            
            CreateTable(
                "dbo.AttendanceReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeName = c.String(nullable: false, maxLength: 10),
                        DateTime = c.DateTime(nullable: false),
                        MId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moderators", t => t.MId, cascadeDelete: true)
                .Index(t => t.MId);
            
            CreateTable(
                "dbo.Moderators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ename = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                        Post = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Salaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MonthName = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Amount = c.String(nullable: false),
                        ReportedBy = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moderators", t => t.ReportedBy, cascadeDelete: true)
                .Index(t => t.ReportedBy);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        ProductPrice = c.Int(nullable: false),
                        CostPrice = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false),
                        PublicImageId = c.String(nullable: false),
                        Description = c.String(nullable: false, unicode: false, storeType: "text"),
                        CategoryId = c.Int(nullable: false),
                        BrandId = c.Int(nullable: false),
                        SoldCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Brands", t => t.BrandId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.BrandId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
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
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        password = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderAddress = c.String(nullable: false),
                        OrderNote = c.String(),
                        OrderStatus = c.String(),
                        PaymentStatus = c.String(),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Int(nullable: false),
                        UnitCostPrice = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
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
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Coupon = c.String(nullable: false, maxLength: 12),
                        Amount = c.Int(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.ProductKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(nullable: false, maxLength: 16),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tkey = c.String(nullable: false, maxLength: 100),
                        CreatedAt = c.DateTime(nullable: false),
                        DeletedAt = c.DateTime(),
                        EmailsId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TotalRevenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Jan = c.Int(nullable: false),
                        Feb = c.Int(nullable: false),
                        Mar = c.Int(nullable: false),
                        Apr = c.Int(nullable: false),
                        May = c.Int(nullable: false),
                        Jun = c.Int(nullable: false),
                        Jul = c.Int(nullable: false),
                        Aug = c.Int(nullable: false),
                        Sep = c.Int(nullable: false),
                        Oct = c.Int(nullable: false),
                        Nov = c.Int(nullable: false),
                        Dec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TotalSales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        Jan = c.Int(nullable: false),
                        Feb = c.Int(nullable: false),
                        Mar = c.Int(nullable: false),
                        Apr = c.Int(nullable: false),
                        May = c.Int(nullable: false),
                        Jun = c.Int(nullable: false),
                        Jul = c.Int(nullable: false),
                        Aug = c.Int(nullable: false),
                        Sep = c.Int(nullable: false),
                        Oct = c.Int(nullable: false),
                        Nov = c.Int(nullable: false),
                        Dec = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandId", "dbo.Brands");
            DropForeignKey("dbo.AttendanceReports", "MId", "dbo.Moderators");
            DropForeignKey("dbo.Salaries", "ReportedBy", "dbo.Moderators");
            DropIndex("dbo.OrderDetails", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Products", new[] { "BrandId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Salaries", new[] { "ReportedBy" });
            DropIndex("dbo.AttendanceReports", new[] { "MId" });
            DropTable("dbo.TotalSales");
            DropTable("dbo.TotalRevenues");
            DropTable("dbo.Tokens");
            DropTable("dbo.Tasks");
            DropTable("dbo.ProductKeys");
            DropTable("dbo.Employees");
            DropTable("dbo.Discounts");
            DropTable("dbo.CustomerTokens");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerProfits");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
            DropTable("dbo.Salaries");
            DropTable("dbo.Moderators");
            DropTable("dbo.AttendanceReports");
            DropTable("dbo.AdminTokens");
            DropTable("dbo.Admins");
            DropTable("dbo.AdminOTPs");
        }
    }
}
