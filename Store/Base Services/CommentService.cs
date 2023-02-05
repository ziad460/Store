using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class CommentService : IBaseService<Comment>
    {
        private readonly ApplicationDbContext context;

        public CommentService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Comment model)
        {
            context.Comments.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Comment comment = context.Comments.FirstOrDefault(mod => mod.Comment_ID == id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }

        public List<Comment> GetAll()
        {
            return context.Comments.ToList();
        }

        public Comment GetByID(int? id)
        {
            Comment comment = context.Comments.FirstOrDefault(mod => mod.Comment_ID == id);
            return comment;
        }

        public void Update(Comment model, int id)
        {
            Comment comment = context.Comments.FirstOrDefault(mod => mod.Comment_ID == id);
            comment.Comment_Date = model.Comment_Date;
            comment.Text = model.Text;
            context.SaveChanges();
        }
    }
}
