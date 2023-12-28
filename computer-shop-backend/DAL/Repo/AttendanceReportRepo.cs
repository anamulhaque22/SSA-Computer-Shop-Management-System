using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class AttendanceReportRepo : Repo, IRepos<AttendanceReport, int, bool>
    {
        public bool Create(AttendanceReport obj)
        {
            db.AttendanceReports.Add(obj);
            if (db.SaveChanges() > 0)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            var ex = Read(id);
            db.AttendanceReports.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public List<AttendanceReport> Read()
        {
            return db.AttendanceReports.ToList();
        }

        public AttendanceReport Read(int id)
        {
            return db.AttendanceReports.Find(id);
        }

        public bool Update(AttendanceReport obj)
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
