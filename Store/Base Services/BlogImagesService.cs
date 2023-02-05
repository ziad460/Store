using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class BlogImagesService : IBaseService<BlogImages>
    {
        private readonly ApplicationDbContext context;

        public BlogImagesService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(BlogImages model)
        {
            context.BlogImages.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            BlogImages images = context.BlogImages.FirstOrDefault(mod => mod.ID == id);
            context.BlogImages.Remove(images);
            context.SaveChanges();
        }

        public List<BlogImages> GetAll()
        {
            return context.BlogImages.ToList();
        }

        public BlogImages GetByID(int? id)
        {
            BlogImages images = context.BlogImages.FirstOrDefault(mod => mod.ID == id);
            return images;
        }

        public void Update(BlogImages model, int id)
        {
            BlogImages images = context.BlogImages.FirstOrDefault(mod => mod.ID == id);
            images.Blog_ID = model.Blog_ID;
            images.Image = model.Image;
            context.SaveChanges();
        }
    }
}
