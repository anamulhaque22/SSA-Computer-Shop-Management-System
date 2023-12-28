namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.EF.PcShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DAL.EF.PcShopContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            /*Random random = new Random();
            for (int i = 1; i <= 10; i++)
            {
                context.Moderators.AddOrUpdate(new EF.Models.Moderator
                {
                    Id = i,
                    Ename = "Ename-" + i,
                    Password = Guid.NewGuid().ToString().Substring(0, 5),
                    Post = "sellesman",
                    Email = Guid.NewGuid().ToString().Substring(0, 5),
                    PhoneNumber = random.Next(1, 6),
                });
            }

            for (int i = 1; i <= 20; i++)
            {
                context.Salaris.AddOrUpdate(new EF.Models.Salary
                {
                    Id = i,
                    MonthName = Guid.NewGuid().ToString(),
                    Date = DateTime.Now,
                    Amount = Guid.NewGuid().ToString(),
                    ReportedBy = random.Next(1, 6),
                });
            }

            for (int i = 1; i <= 30; i++)
            {
                context.AttendanceReports.AddOrUpdate(new EF. Models.AttendanceReport
                {
                    Id = i,
                    EmployeeName = Guid.NewGuid().ToString().Substring(0, 5),
                    DateTime = DateTime.Now,
                    MId = random.Next(1, 11),
                });
            }*/

        }
    }
}
