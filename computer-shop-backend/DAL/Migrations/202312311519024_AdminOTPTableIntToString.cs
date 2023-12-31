namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminOTPTableIntToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AdminOTPs", "Otp", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AdminOTPs", "Otp", c => c.Int(nullable: false));
        }
    }
}
