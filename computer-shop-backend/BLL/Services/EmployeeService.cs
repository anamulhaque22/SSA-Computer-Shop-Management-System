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
            return mapper.Map<EmployeeDTO>(DataAccessFactory.EmployeeData().GetEmployeeOfTheMonth());
        }
    }
}
