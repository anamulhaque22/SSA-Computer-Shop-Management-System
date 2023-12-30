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
    public class TotalSaleService
    {
        public static bool Create(TotalSaleDTO data)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalSaleDTO, TotalSale>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<TotalSale>(data);
            return DataAccessFactory.TotalSaleData().Create(cData);
        }
        public static bool Delete(int Year)
        {
            return DataAccessFactory.TotalSaleData().Delete(Year);
        }
        public static List<TotalSaleDTO> Get()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalSale, TotalSaleDTO>();
            });
            var mapper = new Mapper(config);
            var data = DataAccessFactory.TotalSaleData().Get();
            var cData = mapper.Map<List<TotalSaleDTO>>(data);
            return cData;
        }
        public static TotalSaleDTO Get(int Year)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalSale, TotalSaleDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<TotalSaleDTO>(DataAccessFactory.TotalSaleData().Get(Year));
        }
        public static bool Update(TotalSaleDTO obj)
        {
            var pData = DataAccessFactory.TotalSaleData().Get(obj.Year);
            if(pData == null) { return false; }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TotalSaleDTO, TotalSale>();
            });
            var mapper = new Mapper(config);
            var cData = mapper.Map<TotalSale>(obj);

            if (cData.Jan != 0)
            {
                pData.Jan = cData.Jan;
            }
            else if (cData.Feb != 0)
            {
                pData.Feb = cData.Feb;
            }
            else if (cData.Mar != 0)
            {
                pData.Mar = cData.Mar;
            }
            else if (cData.Apr != 0)
            {
                pData.Apr = cData.Apr;
            }
            else if (cData.May != 0)
            {
                pData.May = cData.May;
            }
            else if (cData.Jun != 0)
            {
                pData.Jun = cData.Jun;
            }
            else if (cData.Jul != 0)
            {
                pData.Jul = cData.Jul;
            }
            else if (cData.Aug != 0)
            {
                pData.Aug = cData.Aug;
            }
            else if (cData.Sep != 0)
            {
                pData.Sep = cData.Sep;
            }
            else if (cData.Nov != 0)
            {
                pData.Nov = cData.Nov;
            }
            else if (cData.Dec != 0)
            {
                pData.Dec = cData.Dec;
            }
            return DataAccessFactory.UpdateTotalSale().Update(pData);
        }
    }
}
