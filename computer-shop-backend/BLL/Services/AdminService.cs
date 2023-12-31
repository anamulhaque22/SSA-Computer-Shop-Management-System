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
        public static bool isUsernameUnique(string username)
        {
            return DataAccessFactory.AdminData().Get(username) == null;
        }
        public static bool isEmailUnique(string email)
        {
            return DataAccessFactory.AdminData().isUniqueEmail(email);
        }
        public static bool Update(AdminUpdateDTO uData, string token) 
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if(pData == null)
            {
                return false;
            }
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AdminUpdateDTO, Admin>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Admin>(uData);
            cData.Username = pUsername;
            return DataAccessFactory.AdminData().Update(cData);
        }
        public static bool UpdatePassword(string token, string password)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return false;
            }
            pData.Password = password;
            return DataAccessFactory.AdminData().UpdateSpecificField(pData);
        }
        public static bool UpdateEmail(string token, string email)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            var pData = DataAccessFactory.AdminData().Get(pUsername);
            if (pData == null)
            {
                return false;
            }
            pData.Email = email;
            return DataAccessFactory.AdminData().UpdateSpecificField(pData);
        }
        public static bool isCurrPassExist(string token, string password)
        {
            var pUsername = DataAccessFactory.AdminTokenData().Read(token).Username;
            return DataAccessFactory.AdminData().Get(pUsername).Password.Equals(password);
        }
    }
}
