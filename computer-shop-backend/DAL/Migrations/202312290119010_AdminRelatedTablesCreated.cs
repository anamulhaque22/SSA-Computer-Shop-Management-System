namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminRelatedTablesCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 16),
                        Otp = c.Int(),
                        Email = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 148),
                        Name = c.String(nullable: false, maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 6),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nid = c.String(nullable: false, maxLength: 15),
                        Phone = c.String(nullable: false, maxLength: 11),
                        Address = c.String(nullable: false, maxLength: 100),
                        PictureName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
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
                        Coupon = c.String(nullable: false, maxLength: 12),
                        Amount = c.Int(nullable: false),
                        ExpireTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TotalRevenues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
            DropTable("dbo.TotalSales");
            DropTable("dbo.TotalRevenues");
            DropTable("dbo.Tasks");
            DropTable("dbo.ProductKeys");
            DropTable("dbo.Discounts");
            DropTable("dbo.Admins");
        }
    }
}
