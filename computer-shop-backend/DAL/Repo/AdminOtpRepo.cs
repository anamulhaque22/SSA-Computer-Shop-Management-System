using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AdminOtpRepo : Repo, IAdminTools<AdminOTP, string, bool>
    {
        public bool Create(AdminOTP obj)
        {
            db.AdminOTPs.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(string username)
        {
            db.AdminOTPs.Remove(db.AdminOTPs.Where(d => d.Username.Equals(username)).FirstOrDefault());
            return db.SaveChanges() > 0;
        }

        public List<AdminOTP> Get()
        {
            throw new NotImplementedException();
        }

        public AdminOTP Get(string username)
        {
            return db.AdminOTPs.Where(d => d.Username.Equals(username)).FirstOrDefault();
        }
    }
}
