using DAL.EF.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class PcShopContext:DbContext
    {
        public DbSet<Moderator> Moderators { get; set; }

        public DbSet<Salary> Salaris { get; set; }

        public DbSet<AttendanceReport> AttendanceReports { get; set; }

        public DbSet<Token> Tokens { get; set; }
    }

    
}
