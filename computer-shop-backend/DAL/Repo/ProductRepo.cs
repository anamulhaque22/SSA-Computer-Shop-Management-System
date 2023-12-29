using DAL.Criteria;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class ProductRepo :Repo, IRepo<Product, int, bool>, IProductRepo<ProductFilterCriteria, Product>
    {
        public bool Create(Product obj)
        {
            db.Products.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            return db.SaveChanges() > 0;
        }

        public List<Product> FilterProduct(ProductFilterCriteria filter)
        {
            var query = db.Products.AsQueryable();

            if (filter.CategoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == filter.CategoryId.Value);
            }

            if (filter.BrandId.HasValue)
            {
                query = query.Where(p => p.BrandId == filter.BrandId.Value);
            }

            if (filter.InStock.HasValue)
            {
                query = query.Where(p => p.Quantity > 0);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(p => p.ProductPrice <= filter.MaxPrice.Value);
            }

            // Apply sorting (ascending or descending)
            
            if (filter.SortAscending)
            {
                query = query.OrderBy(p => p.ProductPrice);
            }
            else
            {
                query = query.OrderByDescending(p => p.ProductPrice);
            }

            // Apply pagination
            if (filter.PageNumber.HasValue && filter.PageSize.HasValue)
            {
                query = query
                    .Skip((filter.PageNumber.Value - 1) * filter.PageSize.Value)
                    .Take(filter.PageSize.Value);
            }

            return query.ToList();
        }

        public List<Product> Read()
        {
            var data = db.Products.ToList();
            return data;
        }

        public Product Read(int id)
        {
            var data = db.Products.Find(id);
            return data;
        }

        public bool Update(Product obj)
        {
            var ex = Read(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
