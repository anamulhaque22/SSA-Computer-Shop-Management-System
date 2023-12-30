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
    public class DiscountService
    {
        public static bool Create(DiscountDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DiscountDTO, Discount>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<Discount>(data);
            return DataAccessFactory.DiscountData().Create(cData);
        }
        public static bool Delete(int Id)
        {
            return DataAccessFactory.DiscountData().Delete(Id);
        }
        public static List<DiscountDTO> Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Discount,DiscountDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.DiscountData().Get();
            var cData = mapper.Map<List<DiscountDTO>>(data);
            return cData;
        }
        public static DiscountDTO Get(int Id)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Discount, DiscountDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<DiscountDTO>(DataAccessFactory.DiscountData().Get(Id));
        }
        public static int isValid(string coupon)
        {
            return DataAccessFactory.DiscountData().isValid(coupon);
        }
    }
}
