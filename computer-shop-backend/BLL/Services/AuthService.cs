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

        public static bool IsTokenVaild(string tkey)
        {
            var extk = DataAccessFactory.TokenData().Read(tkey);
            if (extk != null && extk.DeletedAt == null)
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
