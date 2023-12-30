﻿using DAL.Criteria;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IFacade<Moderator, int, bool> ModeratorData()
        {
            return new ModeratorRepo();
        }

        public static IFacade<Salary, int, bool> SalaryData()
        {
            return new SalaryRepo();
        }

        public static IFacade<AttendanceReport, int, bool> AttendanceReportData()
        {
            return new AttendanceReportRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new ModeratorRepo();
        }

        public static IFacade<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<AdminToken, string, AdminToken> AdminTokenData()
        {
            return new AdminTokenRepo();
        }

        public static IChange ChangePassData()
        {
            return new ModeratorRepo();
        }

        public static IRepo<Category, int, bool> CategoryData()
        {
            return new CategoryRepo();
        }

        public static IRepo<Brand, int, bool> BrandData()
        {
            return new BrandRepo();
        }

        public static IRepo<Product, int, bool>ProductData()
        {
            return new ProductRepo();
        }
        public static IProductRepo<ProductFilterCriteria, Product> ProductFilterData()
        {
            return new ProductRepo();
        }
        public static IAdmin<Admin,string,bool> AdminData() 
        {
            return new AdminRepo();
        }
        public static IProductKey<string,bool> ProductKeyData()
        {
            return new ProductKeyRepo();
        }
        public static IAuth<bool> AdminAuthData()
        {
            return new AdminRepo();
        }
        public static IAdminTools<Discount, int, bool> DiscountData()
        {
            return new DiscountRepo();
        }
        public static IDiscount<int, string> DiscountChecker()
        {
            return new DiscountRepo();
        }
        public static IAdminTools<Task, int, bool> TaskData()
        {
            return new TaskRepo();
        }
        public static IAdminTools<TotalRevenue,int,bool> TotalRevenueData()
        {
            return new TotalRevenuesRepo();
        }
        public static ITotalRevenue<TotalRevenue,bool> UpdateTotalRevenue()
        {
            return new TotalRevenuesRepo();
        }
    }
}
