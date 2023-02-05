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
    public class UserWishListService : IBaseService<UserWishList>
    {
        private readonly ApplicationDbContext context;

        public UserWishListService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(UserWishList model)
        {
            context.UserWishLists.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            UserWishList userWish = context.UserWishLists.FirstOrDefault(mod => mod.UserWishList_ID == id);
            context.UserWishLists.Remove(userWish);
            context.SaveChanges();
        }

        public List<UserWishList> GetAll()
        {
            return context.UserWishLists.Include(mod => mod.Product).ThenInclude(mod => mod.ProductsImages).ToList();
        }

        public UserWishList GetByID(int? id)
        {
            return context.UserWishLists.Include(mod => mod.Product).ThenInclude(mod => mod.ProductsImages).FirstOrDefault(mod => mod.UserWishList_ID == id);
        }

        public void Update(UserWishList model, int id)
        {
            UserWishList userWish = context.UserWishLists.FirstOrDefault(mod => mod.UserWishList_ID == id);
            userWish.Customer_ID = model.Customer_ID;
            userWish.Product_ID = model.Product_ID;
            context.SaveChanges();
        }
    }
}
