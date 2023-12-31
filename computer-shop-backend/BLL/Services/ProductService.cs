﻿using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Utils;
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
            var cloudinary = new CloudinaryService();
            var image = cloudinary.UploadFile(p.FileData, p.FileName);
            
            return DataAccessFactory.ProductData().Create(new Product
            {
                Name = p.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                Description = p.Description,
                ProductPrice = p.ProductPrice,
                CostPrice = p.CostPrice,
                ImageUrl = image.ImageUrl,
                PublicImageId = image.ImagePublicId,//need public id for delete image
            });
        }
        public static ProductCategoryBrandDTO GetAProduct(int id)
        {
            var data = DataAccessFactory.ProductData().Read(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductCategoryBrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt= mapper.Map<ProductCategoryBrandDTO>(data);
            return cnvrt;
        }

        public static List<ProductCategoryBrandDTO> GetAllProduct() {
            var data = DataAccessFactory.ProductData().Read();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductCategoryBrandDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<ProductCategoryBrandDTO>>(data);
            return cnvrt;
        }

        // filtering product
        public static List<ProductCategoryBrandDTO> GetFilteredProduct(ProductFilterDTO p)
        {
            var data = DataAccessFactory.ProductFilterData().FilterProduct(new DAL.Criteria.ProductFilterCriteria
            {
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
                InStock = p.InStock,
                MaxPrice = p.MaxPrice,
                MinPrice = p.MinPrice,
                SortAscending = p.SortAscending,
                PageNumber = p.PageNumber,
                PageSize = p.PageSize
            });
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
        public static bool SaveProductSoldCount(int OrderId) //Have to call this method when Inventory Manager will approve order.
        {
            List<OrderDetail> orderDetails = DataAccessFactory.OrderDetailData().Get(OrderId);
            bool flag = true;
            foreach (var orderDetail in orderDetails)
            {
                var data = DataAccessFactory.ProductData().Read(orderDetail.ProductId);
                data.SoldCount += orderDetail.Quantity;
                if (!DataAccessFactory.ProductData().Update(data))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
        public static ProductDTO GetMostSoldProduct() 
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(config);
            return mapper.Map<ProductDTO>(DataAccessFactory.ProductData().Read().OrderByDescending(p => p.SoldCount).First());
        }
    }
}
