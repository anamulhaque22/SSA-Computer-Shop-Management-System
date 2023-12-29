namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminTokenTableCreated : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminTokens");
        }
    }
}
