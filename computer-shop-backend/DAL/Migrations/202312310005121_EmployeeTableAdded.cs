namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeTableAdded : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
