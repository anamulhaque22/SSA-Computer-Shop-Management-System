using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public bool Create(Category obj)
        {
            var existingBrand = db.Categories.FirstOrDefault(c => c.Name == obj.Name);

            if (existingBrand != null)
            {
                return false;
            }
            else
            {
                db.Categories.Add(obj);
                return db.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Categories.Remove(ex);
            return db.SaveChanges()>0;
        }

        public List<Category> Get()
        {
            var data = db.Categories.ToList();
            return data;
        }

        public Category Get(int id)
        {
            return db.Categories.Find(id);
        }

        public bool Update(Category obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
