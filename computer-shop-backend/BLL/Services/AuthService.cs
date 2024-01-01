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
    public class AuthService
    {
        public static TokenDTO Authenticate(string email, string password) 
        {
            var res = DataAccessFactory.AuthData().Authenticate(email, password);
            if (res)
            {
                var token = new Token();
                token.EmailsId = email;
                token.CreatedAt = DateTime.Now;
                token.Tkey = Guid.NewGuid().ToString();

                var ret = DataAccessFactory.TokenData().Create(token);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<Token, TokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<TokenDTO>(ret);
                }

            }
            return null;
        }
        public static AdminTokenDTO AdminAuthenticate(string username, string password) //AdminRepo
        {
            var res = DataAccessFactory.AdminAuthData().Authenticate(username, password);
            if (res)
            {
                var adminToken = new AdminToken();
                adminToken.Username = username;
                adminToken.CreatedAt = DateTime.Now;
                adminToken.Tkey = Guid.NewGuid().ToString();

                var ret = DataAccessFactory.AdminTokenData().Create(adminToken);
                if (ret != null)
                {
                    var cfg = new MapperConfiguration(c =>
                    {
                        c.CreateMap<AdminToken, AdminTokenDTO>();
                    });
                    var mapper = new Mapper(cfg);
                    return mapper.Map<AdminTokenDTO>(ret);
                }
            }
            return null;
        }
        public static CustomerTokenDTO CustomerAuthenticate(string email, string password)
        {
            var result = DataAccessFactory.CustomerAuthData().Authenticate(email, password);
            if (result)
            {
                //var  exToken = DataAccessFactory.CustomerTokenData.Read()
                var token = new CustomerToken();
                token.Email = email;
                token.CreatedAt = DateTime.Now;
                token.Tkey = Guid.NewGuid().ToString();
                var tokenCreated = DataAccessFactory.CustomerTokenData().Create(token);
                if(tokenCreated != null)
                {
                    return new CustomerTokenDTO
                    {
                        Email = tokenCreated.Email,
                        CreatedAt = tokenCreated.CreatedAt,
                        DeletedAt = tokenCreated.DeletedAt,
                        Tkey = tokenCreated.Tkey,
                    };
                }
            }
            return null;
        }
        public static bool IsCustomerTokenValid(string tkey)
        {
            var extk = DataAccessFactory.CustomerTokenData().Read(tkey);
            if(extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool CustomerLogout(string tkey)
        {
            var extk = DataAccessFactory.CustomerTokenData().Read(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.CustomerTokenData().Update(extk) != null) return true;
            return false;
        }
        public static bool IsTokenVaild(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }
        public static bool IsAdminTokenVaild(string tkey)
        {
            var extk = DataAccessFactory.AdminTokenData().Read(tkey);
            if (extk != null && extk.DeletedAt == null)
            {
                return true;
            }
            return false;
        }

        public static bool AdminLogout(string tkey)
        {
            var extk = DataAccessFactory.AdminTokenData().Read(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.AdminTokenData().Update(extk) != null)
            {
                return true;
            }
            return false;
        }
        public static bool Logout(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            extk.DeletedAt = DateTime.Now;
            if (DataAccessFactory.TokenData().Update(extk) != null)
            {
                return true;
            }
            return false;
        }

    }
}
