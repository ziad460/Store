using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class BlogTagsService : IBaseService<BlogTags>
    {
        private readonly ApplicationDbContext context;

        public BlogTagsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(BlogTags model)
        {
            context.BlogTags.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            BlogTags tags = context.BlogTags.FirstOrDefault(mod => mod.BlogTags_ID == id);
            context.BlogTags.Remove(tags);
            context.SaveChanges();
        }

        public List<BlogTags> GetAll()
        {
            return context.BlogTags.ToList();
        }

        public BlogTags GetByID(int? id)
        {
            BlogTags tags = context.BlogTags.FirstOrDefault(mod => mod.BlogTags_ID == id);
            return tags;
        }

        public void Update(BlogTags model, int id)
        {
            BlogTags tags = context.BlogTags.FirstOrDefault(mod => mod.BlogTags_ID == id);
            tags.Blog_ID = model.Blog_ID;
            tags.Tag_ID = model.Tag_ID;
            context.SaveChanges();
        }
    }
}
