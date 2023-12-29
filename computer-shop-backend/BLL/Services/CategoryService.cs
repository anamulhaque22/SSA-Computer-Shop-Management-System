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
    public class CategoryService
    {
        public static CategoryDTO Get(int id)
        {
            var data = DataAccessFactory.CategoryData().Read(id);
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<CategoryDTO>(data);
            return cnvrt;
        }
        public static List<CategoryDTO> Get()
        {
            var data = DataAccessFactory.CategoryData().Read();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Category, CategoryDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<CategoryDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CategoryData().Delete(id);
        }
        public static bool CreateBrand(CategoryDTO obj)
        {
            return DataAccessFactory.CategoryData().Create(new Category { Name = obj.Name });
        }

        public static bool UpdateBrand(CategoryDTO obj)
        {
            return DataAccessFactory.CategoryData().Update(new Category { Id = obj.ID, Name = obj.Name });
        }
    }
}
