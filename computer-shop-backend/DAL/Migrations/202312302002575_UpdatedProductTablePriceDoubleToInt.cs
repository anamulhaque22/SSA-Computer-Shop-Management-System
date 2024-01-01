namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedProductTablePriceDoubleToInt : DbMigration
    {
        public override void Up()
        {
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
            
            //AddColumn("dbo.Products", "ImageUrl", c => c.String(nullable: false));
            //AddColumn("dbo.Products", "PublicImageId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PublicImageId");
            DropColumn("dbo.Products", "ImageUrl");
            DropTable("dbo.CustomerTokens");
        }
    }
}
