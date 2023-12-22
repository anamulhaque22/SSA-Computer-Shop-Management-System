namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBINIT : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttendanceReports", "MId", "dbo.Moderators");
            DropForeignKey("dbo.Salaries", "ReportedBy", "dbo.Moderators");
            DropIndex("dbo.Salaries", new[] { "ReportedBy" });
            DropIndex("dbo.AttendanceReports", new[] { "MId" });
            DropTable("dbo.Tokens");
            DropTable("dbo.Salaries");
            DropTable("dbo.Moderators");
            DropTable("dbo.AttendanceReports");
        }
    }
}
