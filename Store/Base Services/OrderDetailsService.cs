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
    public class OrderDetailsService : IBaseService<OrderDetails>
    {
        private readonly ApplicationDbContext context;

        public OrderDetailsService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(OrderDetails model)
        {
            context.OrderDetails.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            OrderDetails orderDetails = context.OrderDetails.FirstOrDefault(mod => mod.OrderDetails_ID == id);
            context.OrderDetails.Remove(orderDetails);
            context.SaveChanges();
        }

        public List<OrderDetails> GetAll()
        {
            return context.OrderDetails.Include(mod => mod.Order).ToList();
        }

        public OrderDetails GetByID(int? id)
        {
            return context.OrderDetails.Include(mod => mod.Order).FirstOrDefault(mod => mod.OrderDetails_ID == id);
        }

        public void Update(OrderDetails model, int id)
        {
            OrderDetails orderDetails = context.OrderDetails.FirstOrDefault(mod => mod.OrderDetails_ID == id);
            orderDetails.Order_ID = model.Order_ID;
            orderDetails.Product_Color = model.Product_Color;
            orderDetails.Product_ID = model.Product_ID;
            orderDetails.Product_Quantity = model.Product_Quantity;
            orderDetails.Product_Size = model.Product_Size;
            orderDetails.Total_price = model.Total_price;
            context.SaveChanges();
        }
    }
}
