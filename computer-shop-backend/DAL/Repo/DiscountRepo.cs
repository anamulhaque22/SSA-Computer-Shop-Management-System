using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class DiscountRepo : Repo, IAdminTools<Discount, int, bool>, IDiscount<int, string>
    {
        public bool Create(Discount obj)
        {
            db.Discounts.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            db.Discounts.Remove(db.Discounts.Find(Id));
            return db.SaveChanges() > 0;
        }

        public List<Discount> Get()
        {
            var data = db.Discounts.ToList();
            return data;
        }

        public Discount Get(int Id)
        {
            return db.Discounts.Find(Id);
        }

        public int isValid(string coupon)
        {
            var data = db.Discounts.Where(d => d.Coupon.Equals(coupon)).FirstOrDefault();
            if(data != null)
            {
                return data.Amount;
            }
            else
            {
                return 0;
            }
        }
    }
}
