using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CustomerProfitRepo : Repo, IAdminTools<CustomerProfit, int, bool>, ICustomerProfit<CustomerProfit,bool>
    {
        public bool Create(CustomerProfit obj)
        {
            db.CustomerProfits.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            db.CustomerProfits.Remove(db.CustomerProfits.Find(Id));
            return db.SaveChanges() > 0;
        }

        public List<CustomerProfit> Get()
        {
            return db.CustomerProfits.ToList();
        }

        public CustomerProfit Get(int Id)
        {
            return db.CustomerProfits.Where(d=>d.CusId.Equals(Id)).FirstOrDefault();
        }

        public List<CustomerProfit> GetTop3Customers()
        {
            return db.CustomerProfits.OrderByDescending(d => d.TotalProfit).Take(3).ToList();
        }

        public bool Update(CustomerProfit obj)
        {
            var currData = db.CustomerProfits.Where(d => d.CusId.Equals(obj.CusId)).FirstOrDefault();
            db.Entry(currData).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
