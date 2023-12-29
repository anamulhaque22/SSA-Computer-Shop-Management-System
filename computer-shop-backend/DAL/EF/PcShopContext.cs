using DAL.EF.Models;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace DAL.EF
{
    public class PcShopContext:DbContext
    {

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Moderator> Moderators { get; set; }

        public DbSet<Salary> Salaris { get; set; }

        public DbSet<AttendanceReport> AttendanceReports { get; set; }

        public DbSet<Token> Tokens { get; set; }

        //Admin
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ProductKey> ProductKeys { get; set; }
        public DbSet<Discount> Discounts{ get; set; }
        public DbSet<Admin> Admins{ get; set; }
        public DbSet<TotalRevenue> TotalRevenues { get; set; }
        public DbSet<TotalSale> TotalSales { get; set; }
        public DbSet<AdminToken> AdminTokens { get; set; }
        //Admin
    }


}
