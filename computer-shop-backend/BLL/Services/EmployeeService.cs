using AutoMapper;
using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeService
    {
        public static EmployeeDTO GetEmployeeOfTheMonth()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.EmployeeData().GetEmployeeOfTheMonth();
            data.Password = null;
            return mapper.Map<EmployeeDTO>(data);
        }
        public static int GetTotalEmployeeWage()
        {
            var salaries = DataAccessFactory.SalaryData().Read(); 

            decimal totalAmount = salaries.Sum(s => decimal.Parse(s.Amount));
            return Convert.ToInt32(totalAmount);
        }
        public static List<EmployeeDTO> NonApprovedEmployeeList()
        {
            var data = DataAccessFactory.EmployeeData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<List<EmployeeDTO>>(data.Where(d=>d.AdminApproval==0));
        }
        public static bool AdminApprove(int Id)
        {
            return DataAccessFactory.EmployeeData().Approve(Id);
        }
        public static bool Delete(int Id)
        {
            return DataAccessFactory.EmployeeData().Delete(Id);
        }
    }
}
