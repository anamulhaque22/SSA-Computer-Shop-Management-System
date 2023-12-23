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
        public static ProductDTO GetAProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Get(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt= mapper.Map<ProductDTO>(data);
            return cnvrt;
        }
    }
}
