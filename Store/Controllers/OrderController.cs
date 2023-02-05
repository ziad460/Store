using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IBaseService<Product> productService;
        private readonly IBaseService<Order> orderService;
        private readonly IBaseService<OrderDetails> orderDetailsService;
        private readonly IBaseService<Shipping> shippingService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext context;

        public OrderController(IBaseService<Product> productService ,
                               IBaseService<Order> orderService , 
                               IBaseService<OrderDetails> orderDetailsService ,
                               IBaseService<Shipping> shippingService,
                               UserManager<ApplicationUser> userManager , 
                               ApplicationDbContext context)
        {
            this.productService = productService;
            this.orderService = orderService;
            this.orderDetailsService = orderDetailsService;
            this.shippingService = shippingService;
            this.userManager = userManager;
            this.context = context;
        }
        [NonAction]
        public decimal CalcualteTotal(List<OrderDetails> orderDetails)
        {
            decimal result = 0;
            if (orderDetails.Count != 0)
            {
                foreach (var item in orderDetails)
                {
                    result += item.Total_price;
                }
            }
            return result;
        }

        // id ==========> Product ID
        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity, [Bind(include: "Product_Color , Product_Size")] Product prod)
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Product product = productService.GetByID(id);
            List<Order> orders = orderService.GetAll();
            bool found = false;

            foreach (var item in orders)
            {
                if (item.Customer_ID == user.Id)
                {
                    found = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (found == false)
            {
                Order order = new Order()
                {
                    Customer_ID = user.Id,
                    Order_Total = product.Product_Price * quantity,
                    Order_Status = 0,
                };
                orderService.Add(order);

                OrderDetails orderDetails = new OrderDetails
                {
                    Order_ID = order.Order_ID,
                    Product_ID = product.Product_ID,
                    Product_Quantity = quantity,
                    Total_price = product.Product_Price * quantity,
                    Product_Color = prod.Product_Color,
                    Product_Size = prod.Product_Size
                };
                orderDetailsService.Add(orderDetails);
                return RedirectToAction("Details", "Product", new { id = product.Product_ID });
            }
            else
            {
                var order = context.Orders.Include(model => model.OrderDetails)
                    .FirstOrDefault(model => model.Customer_ID == user.Id);

                bool isFound = false;

                foreach (var item in order.OrderDetails)
                {
                    if (item.Product_ID == product.Product_ID)
                    {
                        isFound = true;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                if (isFound)
                {
                    OrderDetails orderDetails = context.OrderDetails
                        .FirstOrDefault(model => model.Product_ID == product.Product_ID);

                    orderDetails.Product_Quantity = quantity;
                    orderDetails.Total_price = orderDetails.Product_Quantity * product.Product_Price;
                    context.SaveChanges();

                    order.Order_Total = CalcualteTotal(order.OrderDetails);
                    context.SaveChanges();
                    return RedirectToAction("Details", "Product", new { id = product.Product_ID });
                }
                else
                {
                    OrderDetails orderDetails = new OrderDetails()
                    {
                        Order_ID = order.Order_ID,
                        Product_ID = product.Product_ID,
                        Product_Quantity = quantity,
                        Total_price = product.Product_Price * quantity,
                        Product_Color = prod.Product_Color,
                        Product_Size = prod.Product_Size
                    };
                    orderDetailsService.Add(orderDetails);

                    order.Order_Total = CalcualteTotal(order.OrderDetails);
                    context.SaveChanges();
                    return RedirectToAction("Details", "Product", new { id = product.Product_ID });
                }
            }
        }

        public async Task<IActionResult> Cart()
        {
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);

            Order order = context.Orders.Include(mod => mod.Customer).Include(mod => mod.Shipping)
                .Include(model => model.OrderDetails)
                .ThenInclude(model => model.Product).ThenInclude(model => model.ProductsImages)
                .FirstOrDefault(model => model.Customer_ID == user.Id);

            ViewBag.Total = order.Order_Total + 5;

            if (order == null)
            {
                Order ord = new Order
                {
                    Customer_ID = user.Id
                };
                orderService.Add(ord);
                ViewBag.Total = 5;
            }
            return View(order);
        }
        public async Task<IActionResult> UpdateCart(IEnumerable<OrderDetails> orderDetails)
        {
            List<OrderDetails> orders = orderDetails.ToList();
            IdentityUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            Order ord = context.Orders.Include(m => m.OrderDetails).ThenInclude(m => m.Product).FirstOrDefault(m => m.Customer_ID == user.Id);

            for (int i = 0; i < ord.OrderDetails.Count; i++)
            {
                if (orders[i] != ord.OrderDetails[i])
                {
                    ord.OrderDetails[i].Product_Quantity = orders[i].Product_Quantity;
                    ord.OrderDetails[i].Total_price = orders[i].Product_Quantity * ord.OrderDetails[i].Product.Product_Price;
                    context.SaveChanges();
                    ord.Order_Total = CalcualteTotal(ord.OrderDetails);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Cart");
        }

        // id ================> OrderDetails Id
        public IActionResult DeleteFromCart(int id)
        {
            OrderDetails orderDetails = orderDetailsService.GetByID(id);

            orderDetails.Order.Order_Total -= orderDetails.Total_price;
            context.SaveChanges();

            context.OrderDetails.Remove(orderDetails);
            context.SaveChanges();

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public async Task<IActionResult> CheckOut(ShipperViewModel shipperModel)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(User.Identity.Name);
            user.Address = shipperModel.Address;
            user.PhoneNumber = shipperModel.PhoneNumber;
            context.SaveChanges();
            Shipping shipping = new Shipping
            {
                CustomerName = shipperModel.CustomerName,
                Customer_ID = user.Id,
                Postal_Code = shipperModel.Postal_Code,
                Shipping_Email = shipperModel.Email,
            };
            shippingService.Add(shipping);

            Order order = context.Orders.FirstOrDefault(model => model.Customer_ID == user.Id);
            order.Shipping_ID = shipping.Shipping_ID;
            context.SaveChanges();

            List<OrderDetails> orderDetails = context.OrderDetails.Include(model => model.Product)
                .Where(model => model.Order_ID == order.Order_ID).ToList();

            foreach (var item in orderDetails)
            {
                item.Product.Stored_Quantity -= item.Product_Quantity;
                item.Product.Popularity += 1;
            }
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
