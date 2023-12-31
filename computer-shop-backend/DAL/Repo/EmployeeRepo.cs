using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class EmployeeRepo : Repo, IEmployee<Employee>
    {
        public Employee GetEmployeeOfTheMonth()
        {
            return db.Employees.OrderByDescending(e => e.CurrentRating).FirstOrDefault();
        }
    }
}
