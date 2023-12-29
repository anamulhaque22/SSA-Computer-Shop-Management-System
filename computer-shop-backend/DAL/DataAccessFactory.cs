using DAL.Criteria;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Moderator, int, bool> ModeratorData()
        {
            return new ModeratorRepo();
        }

        public static IRepo<Salary, int, bool> SalaryData()
        {
            return new SalaryRepo();
        }

        public static IRepo<AttendanceReport, int, bool> AttendanceReportData()
        {
            return new AttendanceReportRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new ModeratorRepo();
        }

        public static IRepo<Token, string, Token> TokenData()
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
        public static IAdminRepo<Admin,string,bool> AdminData() 
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
    }
}
