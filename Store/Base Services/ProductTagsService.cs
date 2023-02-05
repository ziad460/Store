using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class ProductTagsService : IBaseService<ProductTags>
    {
        private readonly ApplicationDbContext context;

        public ProductTagsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(ProductTags model)
        {
            context.ProductTags.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ProductTags tags = context.ProductTags.FirstOrDefault(mod => mod.ProductTags_ID == id);
            context.ProductTags.Remove(tags);
            context.SaveChanges();
        }

        public List<ProductTags> GetAll()
        {
            return context.ProductTags.ToList();
        }

        public ProductTags GetByID(int? id)
        {
            ProductTags tags = context.ProductTags.FirstOrDefault(mod => mod.ProductTags_ID == id);
            return tags;
        }

        public void Update(ProductTags model, int id)
        {
            ProductTags tags = context.ProductTags.FirstOrDefault(mod => mod.ProductTags_ID == id);
            tags.Product_ID = model.Product_ID;
            tags.Tag_ID = model.Tag_ID;
            context.SaveChanges();
        }
    }
}
