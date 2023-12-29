using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ProductKeyRepo : Repo, IProductKey<string, bool>
    {
        public bool Delete(string Key)
        {
            db.ProductKeys.Remove(db.ProductKeys.Where(d => d.Key.Equals(Key)).FirstOrDefault());
            return db.SaveChanges() > 0;
        }

        public bool IsValid(string key)
        {
            if(db.ProductKeys.Where(d => d.Key.Equals(key)).FirstOrDefault() != null)
            {
                return true;
            }
            return false;
        }
    }
}
