using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Base_Interfaces;
using Store.Data;
using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IBaseService<Product> productService;
        private readonly IBaseService<Category> categoryService;
        private readonly IBaseService<ProductsImages> productImagesService;
        private readonly IFilterService<Product> filterService;
        private readonly ApplicationDbContext context;

        public ProductController(IBaseService<Product> productService ,
                                 IBaseService<Category> categoryService ,
                                 IBaseService<ProductsImages> productImagesService,
                                 IFilterService<Product> filterService ,
                                 ApplicationDbContext context)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.productImagesService = productImagesService;
            this.filterService = filterService;
            this.context = context;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 12;
            return View(productService.GetAll().ToPagedList(pageNumber,pageSize));
        }
        public IActionResult Search(int? search)
        {
            if (search == null)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { id = search });
        }
        public IActionResult Details(int id)
        {
            Product product = productService.GetByID(id);
            return View(product);
        }
        public IActionResult Add()
        {
            ViewBag.Categories = categoryService.GetAll();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Product product, [FromForm] List<string> ProductGallary)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = categoryService.GetAll();
                    return View(product);
                }
                productService.Add(product);
                foreach (var item in ProductGallary)
                {
                    ProductsImages images = new ProductsImages
                    {
                        Image = item,
                        Product_ID = product.Product_ID
                    };
                    productImagesService.Add(images);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                ViewBag.Categories = categoryService.GetAll();
                return View(product);
            }
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Categories = categoryService.GetAll();
            return View(productService.GetByID(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product, [FromForm] List<string> ProductGallary)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Categories = categoryService.GetAll();
                    return View(product);
                }
                productService.Update(product, product.Product_ID);
                foreach (var item in ProductGallary)
                {
                    ProductsImages images = new ProductsImages
                    {
                        Image = item,
                        Product_ID = product.Product_ID
                    };
                    productImagesService.Add(images);
                }
                return RedirectToAction("Details" , new { id = product.Product_ID});
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                ViewBag.Categories = categoryService.GetAll();
                return View(product);
            }
        }
        public IActionResult EditImages(int id)
        {
            ProductsImages image = productImagesService.GetByID(id);
            if (image == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.Categories = categoryService.GetAll();
            Product product = context.Products.FirstOrDefault(mod => mod.Product_ID == image.Product_ID);
            productImagesService.Delete(id);
            return View("Edit" , product);
        }
        public IActionResult Delete(int id)
        {
            Product product = productService.GetByID(id);
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            productService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
