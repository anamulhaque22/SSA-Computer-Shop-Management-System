using BLL.DTOs;
using DAL.EF.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace BLL.Services
{
    public class AdminService
    {
        public static bool Signup(AdminSingupDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminSingupDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Admin>(data);
            return DataAccessFactory.AdminData().Create(cData);
        }
        public static AdminDTO Get(string username) 
        {
            var data = DataAccessFactory.AdminData().Get(username);
            if(data == null)
            {
                return null;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Admin, AdminDTO>();
            });
            var mapper = new Mapper(config);
            data.Password = null;
            data.Otp = null;
            return mapper.Map<AdminDTO>(data);
        }
        public static bool Update(string username) 
        {
            var data = DataAccessFactory.AdminData().Get(username);
            if(data == null)
            {
                return false;
            }
            return DataAccessFactory.AdminData().Update(data);
        }
    }
}
