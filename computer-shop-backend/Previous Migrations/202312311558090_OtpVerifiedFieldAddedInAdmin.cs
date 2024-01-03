namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OtpVerifiedFieldAddedInAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "OtpVerified", c => c.Int(nullable: false));
            DropColumn("dbo.Admins", "Otp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Otp", c => c.Int());
            DropColumn("dbo.Admins", "OtpVerified");
        }
    }
}
