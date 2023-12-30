using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TotalRevenuesRepo : Repo, IAdminTools<TotalRevenue, int, bool>, ITotalRevenue<TotalRevenue,bool>
    {
        public bool Create(TotalRevenue obj)
        {
            db.TotalRevenues.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Year)
        {
            db.TotalRevenues.Remove(db.TotalRevenues.Where(d => d.Year.Equals(Year)).FirstOrDefault());
            return db.SaveChanges() > 0;
        }

        public List<TotalRevenue> Get()
        {
            return db.TotalRevenues.ToList();
        }

        public TotalRevenue Get(int Year)
        {
            return db.TotalRevenues.Where(d => d.Year.Equals(Year)).FirstOrDefault();
        }

        public bool Update(TotalRevenue obj)
        {
            var data = db.TotalRevenues.Find(obj.Id);
            db.Entry(data).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
