using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class TagsService : IBaseService<Tags>
    {
        private readonly ApplicationDbContext context;

        public TagsService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Tags model)
        {
            context.Tags.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Tags tags = context.Tags.FirstOrDefault(mod => mod.Tag_ID == id);
            context.Tags.Remove(tags);
            context.SaveChanges();
        }

        public List<Tags> GetAll()
        {
            return context.Tags.ToList();
        }

        public Tags GetByID(int? id)
        {
            return context.Tags.FirstOrDefault(mod => mod.Tag_ID == id);
        }

        public void Update(Tags model, int id)
        {
            Tags tags = context.Tags.FirstOrDefault(mod => mod.Tag_ID == id);
            tags.Tag_Description = model.Tag_Description;
            tags.Tag_Name = model.Tag_Name;
            context.SaveChanges();
        }
    }
}
