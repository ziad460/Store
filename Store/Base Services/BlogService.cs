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
    public class BlogService : IBaseService<Blog>, IFilterService<Blog>
    {
        private readonly ApplicationDbContext context;

        public BlogService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Blog model)
        {
            context.Blogs.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Blog blog = context.Blogs.FirstOrDefault(mod => mod.Blog_ID == id);
            context.Blogs.Remove(blog);
            context.SaveChanges();
        }

        // Not Completed
        public List<Blog> FilterByCategory(int? id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> FilterByName(string name)
        {
            List<Blog> blogs = context.Blogs.Where(mod => mod.Blog_Title.Contains(name)).ToList();
            return blogs;
        }

        // Not Completed
        public List<Blog> FilterByPrice(int? price)
        {
            throw new NotImplementedException();
        }

        public List<Blog> FilterByTags(int? id)
        {
            List<Blog> blogs = context.BlogTags.Where(mod => mod.BlogTags_ID == id)
                                .Include(mod => mod.Blog).Select(mod => mod.Blog).ToList();
            return blogs;
        }

        public List<Blog> GetAll()
        {
            return context.Blogs.ToList();
        }

        public Blog GetByID(int? id)
        {
            Blog blog = context.Blogs.FirstOrDefault(mod => mod.Blog_ID == id);
            return blog;
        }

        public void Update(Blog model, int id)
        {
            Blog blog = context.Blogs.FirstOrDefault(mod => mod.Blog_ID == id);
            blog.Blog_Content = model.Blog_Content;
            blog.Blog_Date = model.Blog_Date;
            blog.Blog_Title = model.Blog_Title;
            context.SaveChanges();
        }
    }
}
