using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BrandService
    {
        public static BrandDTO Get(int id)
        {
            var data = DataAccessFactory.BrandData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<BrandDTO>(data);
            return cnvrt;
        }
        public static List<BrandDTO> Get()
        {
            var data = DataAccessFactory.BrandData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Brand, BrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<BrandDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.BrandData().Delete(id);
        }
        public static bool CreateBrand(BrandDTO brand)
        {
            return DataAccessFactory.BrandData().Create(new Brand { Name = brand.Name });
        }

        public static bool UpdateBrand(BrandDTO brand)
        {
            return DataAccessFactory.BrandData().Update(new Brand { Id = brand.ID, Name = brand.Name });
        }
    }
}
