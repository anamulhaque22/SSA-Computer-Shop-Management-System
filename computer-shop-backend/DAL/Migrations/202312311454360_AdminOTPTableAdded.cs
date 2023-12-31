namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminOTPTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminOTPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Otp = c.Int(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminOTPs");
        }
    }
}
