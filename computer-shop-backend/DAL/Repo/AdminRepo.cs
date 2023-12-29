using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminRepo : Repo, IAdminRepo<Admin, string, bool>, IAuth<bool>
    {

        public bool Create(Admin obj)
        {
            db.Admins.Add(obj);
            return db.SaveChanges() > 0;
        }

        public Admin Get(string username)
        {
            return db.Admins.Find(username);
        }

        public bool Update(Admin obj)
        {
            db.Entry(obj).CurrentValues.SetValues(db.Admins.Find(obj.Username));
            return db.SaveChanges()>0;   
        }

        public bool Authenticate(string username, string password)
        {
            return db.Admins.Where(d => d.Username.Equals(username) && d.Password.Equals(password)).Count() > 0;
        }
    }
}
