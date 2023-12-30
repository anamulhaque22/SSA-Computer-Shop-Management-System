using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repo
{
    internal class CustomerTokenRepo : Repo, IRepo<CustomerToken, string, CustomerToken>
    {
        public CustomerToken Create(CustomerToken obj)
        {
            db.CustomerTokens.Add(obj);
            if(db.SaveChanges()>0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerToken> Read()
        {
            throw new NotImplementedException();
        }

        public CustomerToken Read(string id)
        {
            return db.CustomerTokens.FirstOrDefault(ct => ct.Tkey.Equals(id));
            
        }

        public CustomerToken Update(CustomerToken obj)
        {
            var token = Read(obj.Tkey);
            db.Entry(token).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0) return token;
            return null;
        }
    }
}
