namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationErrorUpdated : DbMigration
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
            
            //AddColumn("dbo.Admins", "OtpVerified", c => c.Int(nullable: false));
            //AddColumn("dbo.Products", "SoldCount", c => c.Int(nullable: false));
            //DropColumn("dbo.Admins", "Otp");
           // DropColumn("dbo.CustomerProfits", "TempTotalProfit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerProfits", "TempTotalProfit", c => c.Int(nullable: false));
            AddColumn("dbo.Admins", "Otp", c => c.Int());
            DropColumn("dbo.Products", "SoldCount");
            DropColumn("dbo.Admins", "OtpVerified");
            DropTable("dbo.Employees");
            DropTable("dbo.AdminOTPs");
        }
    }
}
