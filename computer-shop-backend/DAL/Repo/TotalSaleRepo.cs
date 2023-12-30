using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TotalSaleRepo : Repo, IAdminTools<TotalSale, int, bool>, ITotalSales<TotalSale, bool>
    {
        public bool Create(TotalSale obj)
        {
            db.TotalSales.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Year)
        {
            db.TotalSales.Remove(db.TotalSales.Where(d => d.Year.Equals(Year)).FirstOrDefault());
            return db.SaveChanges() > 0;
        }

        public List<TotalSale> Get()
        {
            return db.TotalSales.ToList();
        }

        public TotalSale Get(int Year)
        {
            return db.TotalSales.Where(d => d.Year.Equals(Year)).FirstOrDefault();
        }

        public bool Update(TotalSale obj)
        {
            var data = db.TotalSales.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
