namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pictureNameNullAsDefault : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "PictureName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "PictureName", c => c.String(nullable: false, maxLength: 100));
        }
    }
}
