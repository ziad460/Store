using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class ProductImagesService: IBaseService<ProductsImages>
    {
        private readonly ApplicationDbContext context;

        public ProductImagesService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(ProductsImages model)
        {
            context.ProductsImages.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProductsImages images = context.ProductsImages.FirstOrDefault(mod => mod.ID == id);
            context.ProductsImages.Remove(images);
            context.SaveChanges();
        }

        public List<ProductsImages> GetAll()
        {
            return context.ProductsImages.ToList();
        }

        public ProductsImages GetByID(int? id)
        {
            ProductsImages images = context.ProductsImages.FirstOrDefault(mod => mod.ID == id);
            return images;
        }

        public void Update(ProductsImages model, int id)
        {
            ProductsImages images = context.ProductsImages.FirstOrDefault(mod => mod.ID == id);
            images.Product_ID = model.Product_ID;
            images.Image = model.Image;
            context.SaveChanges();
        }
    }
}
