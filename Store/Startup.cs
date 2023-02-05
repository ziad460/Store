using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Store.Base_Interfaces;
using Store.Base_Services;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ZiadConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<ApplicationUser , IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddScoped(typeof(IBaseService<Product>), typeof(ProductService));
            services.AddScoped(typeof(IFilterService<Product>), typeof(ProductService));
            services.AddScoped(typeof(IBaseService<Blog>), typeof(BlogService));
            services.AddScoped(typeof(IBaseService<Comment>), typeof(CommentService));
            services.AddScoped(typeof(IBaseService<BlogImages>), typeof(BlogImagesService));
            services.AddScoped(typeof(IBaseService<BlogTags>), typeof(BlogTagsService));
            services.AddScoped(typeof(IBaseService<Category>), typeof(CategoryService));
            services.AddScoped(typeof(IBaseService<OrderDetails>), typeof(OrderDetailsService));
            services.AddScoped(typeof(IBaseService<Order>), typeof(OrderService));
            services.AddScoped(typeof(IBaseService<Payment>), typeof(PaymentService));
            services.AddScoped(typeof(IBaseService<ProductsImages>), typeof(ProductImagesService));
            services.AddScoped(typeof(IBaseService<ProductTags>), typeof(ProductTagsService));
            services.AddScoped(typeof(IBaseService<Shipping>), typeof(ShippingService));
            services.AddScoped(typeof(IBaseService<Tags>), typeof(TagsService));
            services.AddScoped(typeof(IBaseService<UserWishList>), typeof(UserWishListService));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Admin",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
