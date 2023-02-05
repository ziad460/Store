using Microsoft.EntityFrameworkCore;
using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class ProductService : IBaseService<Product>, IFilterService<Product>
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Product model)
        {
            context.Products.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = context.Products.FirstOrDefault(mod => mod.Product_ID == id);
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public List<Product> FilterByCategory(int? id)
        {
            List<Product> products = context.Products.Include(mod => mod.ProductsImages).Where(mod => mod.Category_ID == id).ToList();
            return products;
        }

        public List<Product> FilterByName(string name)
        {
            List<Product> products = context.Products.Include(mod => mod.ProductsImages).Where(prod => prod.Product_Name.Contains(name)).ToList();
            return products;
        }

        public List<Product> FilterByPrice(int? price)
        {
            List<Product> products;
            switch (price)
            {
                case (0):
                    products = context.Products.Include(mod => mod.ProductsImages).Where(model => model.Product_Price > 0 && model.Product_Price <= 100).ToList();
                    break;
                case (100):
                    products = context.Products.Include(mod => mod.ProductsImages).Where(model => model.Product_Price > 100 && model.Product_Price <= 150).ToList();
                    break;
                case (150):
                    products = context.Products.Include(mod => mod.ProductsImages).Where(model => model.Product_Price > 150 && model.Product_Price <= 200).ToList();
                    break;
                case (200):
                    products = context.Products.Include(mod => mod.ProductsImages).Where(model => model.Product_Price > 200).ToList();
                    break;
                default:
                    products = context.Products.Include(mod => mod.ProductsImages).ToList();
                    break;
            }
            return products;
        }

        public List<Product> FilterByTags(int? id)
        {
            List<Product> products = context.ProductTags.Where(model => model.Tag_ID == id)
                                    .Include(model => model.Product).ThenInclude(mod => mod.ProductsImages)
                                    .Select(model => model.Product).ToList();
            return products;
        }

        public List<Product> GetAll()
        {
            return context.Products.Include(mod => mod.ProductsImages).ToList();
        }

        public Product GetByID(int? id)
        {
            return context.Products.Include(mod => mod.Category).Include(mod => mod.ProductsImages).FirstOrDefault(mod => mod.Product_ID == id);
        }

        public void Update(Product model, int id)
        {
            Product product = context.Products.FirstOrDefault(mod => mod.Product_ID == id);

            product.Adding_Date = model.Adding_Date;
            product.Category_ID = model.Category_ID;
            product.Description = model.Description;
            product.Popularity = model.Popularity;
            product.Product_Color = model.Product_Color;
            product.Product_Name = model.Product_Name;
            product.Product_Price = model.Product_Price;
            product.Product_Size = model.Product_Size;
            product.Stored_Quantity = model.Stored_Quantity;

            context.SaveChanges();
        }
    }
}
