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
    public class ProductService
    {
        public static bool AddProduct(ProductCreateDTO p)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCreateDTO, Product>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<Product>(p);
            return DataAccessFactory.ProductData().Create(cnvrt);
        }
        public static ProductCategoryBrandDTO GetAProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductCategoryBrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt= mapper.Map<ProductCategoryBrandDTO>(data);
            return cnvrt;
        }

        public static List<ProductCategoryBrandDTO> GetAllProduct() {
            var data = DataAccessFactory.ProductData().Get();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductCategoryBrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<ProductCategoryBrandDTO>>(data);
            return cnvrt;
        }

        public static bool UpdateProduct(ProductCreateDTO p)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ProductCreateDTO, Product>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<Product>(p);
            return DataAccessFactory.ProductData().Update(cnvrt);
        }

        public static bool DeleteProduct(int id)
        {
            return DataAccessFactory.ProductData().Delete(id);
        }
    }
}
