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
    internal class AdminRepo : Repo, IAdmin<Admin, string, bool>, IAuth<bool>
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
        public bool UpdateSpecificField(Admin obj)
        {
            var pData = db.Admins.Find(obj.Username);
            db.Entry(pData).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public bool Update(Admin obj)
        {
            var pData = db.Admins.Find(obj.Username);
            obj.Email = pData.Email;
            obj.Password = pData.Password;
            obj.Otp = pData.Otp;
            db.Entry(pData).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;   
        }

        public bool Authenticate(string username, string password)
        {
            return db.Admins.Where(d => d.Username.Equals(username) && d.Password.Equals(password)).Count() > 0;
        }

        public bool isUniqueEmail(string email)
        {
            return db.Admins.Where(d=>d.Email.Equals(email)).Count() == 0;
        }
    }
}
