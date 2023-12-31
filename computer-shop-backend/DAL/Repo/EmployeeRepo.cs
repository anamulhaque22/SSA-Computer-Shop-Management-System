using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeRepo : Repo, IEmployee<Employee, bool, int>
    {
        public bool Approve(int Id)
        {
            var data = db.Employees.Find(Id);
            if (data == null) { return false; }
            data.AdminApproval = 1;
            db.Entry(data).CurrentValues.SetValues(data);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int Id)
        {
            var data = db.Employees.Find(Id);
            if(data == null) { return false; }
            db.Employees.Remove(data);
            return db.SaveChanges() > 0;
        }

        public List<Employee> Get()
        {
            return db.Employees.ToList();
        }

        public Employee GetEmployeeOfTheMonth()
        {
            return db.Employees.OrderByDescending(e => e.CurrentRating).FirstOrDefault();
        }

    }
}
