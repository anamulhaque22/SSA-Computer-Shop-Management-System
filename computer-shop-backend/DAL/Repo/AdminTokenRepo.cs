using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminTokenRepo : Repo, IRepo<AdminToken, string, AdminToken>
    {
        public AdminToken Create(AdminToken obj)
        {
            db.AdminTokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<AdminToken> Read()
        {
            throw new NotImplementedException();
        }

        public AdminToken Read(string Tkey)
        {
            //return db.AdminTokens.FirstOrDefault(t => t.Tkey.Equals(id));
            return db.AdminTokens.Where(d=>d.Tkey.Equals(Tkey)).FirstOrDefault();
        }

        public AdminToken Update(AdminToken obj)
        {
            var adminToken = Read(obj.Tkey);
            db.Entry(adminToken).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return adminToken;
            return null;
        }
    }
}
