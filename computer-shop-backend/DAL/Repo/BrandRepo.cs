using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BrandRepo : Repo, IRepo<Brand, int, bool>
    {
        public bool Create(Brand obj)
        {
            var existingBrand = db.Brands.FirstOrDefault(b => b.Name == obj.Name);

            if (existingBrand != null)
            {
                return false;
            }
            else
            {
                db.Brands.Add(obj);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Brands.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Brand> Get()
        {
            var data = db.Brands.ToList();
            return data;
        }

        public Brand Get(int id)
        {
            return db.Brands.Find(id);
        }

        public bool Update(Brand obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
