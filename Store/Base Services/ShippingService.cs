using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class ShippingService : IBaseService<Shipping>
    {
        private readonly ApplicationDbContext context;

        public ShippingService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Shipping model)
        {
            context.Shippings.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Shipping shipping = context.Shippings.FirstOrDefault(mod => mod.Shipping_ID == id);
            context.Shippings.Remove(shipping);
            context.SaveChanges();
        }

        public List<Shipping> GetAll()
        {
            return context.Shippings.ToList();
        }

        public Shipping GetByID(int? id)
        {
            return context.Shippings.FirstOrDefault(mod => mod.Shipping_ID == id);
        }

        public void Update(Shipping model, int id)
        {
            Shipping shipping = context.Shippings.FirstOrDefault(mod => mod.Shipping_ID == id);
            shipping.Customer_ID = model.Customer_ID;
            shipping.Notes = model.Notes;
            shipping.Postal_Code = model.Postal_Code;
            context.SaveChanges();
        }
    }
}
