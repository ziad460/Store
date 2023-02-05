using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Base_Services
{
    public class PaymentService : IBaseService<Payment>
    {
        private readonly ApplicationDbContext context;

        public PaymentService(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void Add(Payment model)
        {
            context.Payments.Add(model);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Payment payment = context.Payments.FirstOrDefault(mod => mod.Payment_ID == id);
            context.Payments.Remove(payment);
            context.SaveChanges();
        }

        public List<Payment> GetAll()
        {
            return context.Payments.ToList();
        }

        public Payment GetByID(int? id)
        {
            return context.Payments.FirstOrDefault(mod => mod.Payment_ID == id);
        }

        public void Update(Payment model, int id)
        {
            Payment payment = context.Payments.FirstOrDefault(mod => mod.Payment_ID == id);
            payment.PaymentMethod = model.PaymentMethod;
            context.SaveChanges();
        }
    }
}
