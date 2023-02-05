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
    public class OrderService : IBaseService<Order>
    {
        private readonly ApplicationDbContext context;

        public OrderService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Order model)
        {
            context.Orders.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Order order = context.Orders.FirstOrDefault(mod => mod.Order_ID == id);
            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public List<Order> GetAll()
        {
            return context.Orders.Include(mod => mod.Customer)
                .Include(mod => mod.OrderDetails).ThenInclude(mod => mod.Product)
                .ThenInclude(mod => mod.ProductsImages).ToList();
        }

        public Order GetByID(int? id)
        {
            return context.Orders.Include(mod => mod.Customer)
                .Include(mod => mod.OrderDetails).ThenInclude(mod => mod.Product)
                .ThenInclude(mod => mod.ProductsImages).FirstOrDefault(mod => mod.Order_ID == id);
        }

        public void Update(Order model, int id)
        {
            Order order = context.Orders.FirstOrDefault(mod => mod.Order_ID == id);
            order.Order_Status = model.Order_Status;
            order.Order_Total = model.Order_Total;
            order.Payment_ID = model.Payment_ID;
            order.Shipping_ID = model.Shipping_ID;
            context.SaveChanges();
        }
    }
}
