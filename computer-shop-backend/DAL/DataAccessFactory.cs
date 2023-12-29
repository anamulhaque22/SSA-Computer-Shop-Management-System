using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IFacade<Moderator, int, bool> ModeratorData()
        {
            return new ModeratorRepo();
        }

        public static IFacade<Salary, int, bool> SalaryData()
        {
            return new SalaryRepo();
        }

        public static IFacade<AttendanceReport, int, bool> AttendanceReportData()
        {
            return new AttendanceReportRepo();
        }

        public static IAuth<bool> AuthData()
        {
            return new ModeratorRepo();
        }

        public static IFacade<Token, string, Token> TokenData()
        {
            return new TokenRepo();
        }

        public static IChange ChangePassData()
        {
            return new ModeratorRepo();
        }

    }
}
