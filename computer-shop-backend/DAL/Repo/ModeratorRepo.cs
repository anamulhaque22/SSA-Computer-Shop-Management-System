using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class ModeratorRepo : Repo, IRepos<Moderator, int, bool>, IAuth<bool>, IChange
    {
        public bool Authenticate(string email, string password)
        {
            var data = db.Moderators.FirstOrDefault(u => u.Email.Equals(email) &&
            u.Password.Equals(password));
            if (data != null) return true;
            return false;
        }

        public bool ChangePassword(int Id, string password)
        {
            var moderator = Read(Id);
            moderator.Password = password;
            return db.SaveChanges() > 0;
        }

        public bool Create(Moderator obj)
        {
            db.Moderators.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.Moderators.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<Moderator> Read()
        {
            return db.Moderators.ToList();
        }

        public Moderator Read(int id)
        {
            return db.Moderators.Find(id);
        }

        public bool Update(Moderator obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }
        public Dictionary<string, decimal> ReadForPieChart()

        {

            throw new NotImplementedException();

        }
    }
}
