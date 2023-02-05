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
    public class CategoryService : IBaseService<Category>
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Category model)
        {
            context.Categories.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = context.Categories.FirstOrDefault(mod => mod.Category_ID == id);
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public List<Category> GetAll()
        {
            return context.Categories.Include(mod => mod.Products).ThenInclude(mod => mod.ProductsImages).ToList();
        }

        public Category GetByID(int? id)
        {
            Category category = context.Categories.Include(mod => mod.Products).ThenInclude(mod => mod.ProductsImages).FirstOrDefault(mod => mod.Category_ID == id);
            return category;
        }

        public void Update(Category model, int id)
        {
            Category category = context.Categories.FirstOrDefault(mod => mod.Category_ID == id);
            category.Category_Describtion = model.Category_Describtion;
            category.Category_Name = model.Category_Name;
            context.SaveChanges();
        }
    }
}
