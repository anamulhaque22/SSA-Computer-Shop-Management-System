using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repo
{
    internal class TaskRepo : Repo, IAdminTools<Task, int, bool>
    {
        public bool Create(Task obj)
        {
            db.Tasks.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            db.Tasks.Remove(db.Tasks.Find(Id));
            return db.SaveChanges() > 0;
        }

        public List<Task> Get()
        {
            return db.Tasks.ToList();
        }

        public Task Get(int Id)
        {
            return db.Tasks.Find(Id);
        }
    }
}
