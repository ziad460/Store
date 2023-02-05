using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Base_Interfaces;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBaseService<Product> productService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IBaseService<Category> categoryService;
        private readonly IBaseService<Tags> tagsService;
        private readonly IBaseService<UserWishList> wishListService;
        private readonly IFilterService<Product> filterService;

        public ProductController(IBaseService<Product> productService ,
                                UserManager<ApplicationUser> userManager,
                                IBaseService<Category> categoryService , 
                                IBaseService<Tags> tagsService ,
                                IBaseService<UserWishList> wishListService,
                                IFilterService<Product> filterService)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.categoryService = categoryService;
            this.tagsService = tagsService;
            this.wishListService = wishListService;
            this.filterService = filterService;
        }
        public List<Product> SortingItems(int? id)
        {
            List<Product> products;
            switch (id)
            {
                case (1):
                    products = productService.GetAll()
                            .OrderByDescending(model => model.Popularity).ToList();
                    break;
                case (2):
                    products = productService.GetAll()
                            .OrderByDescending(model => model.Adding_Date).ToList();
                    break;
                case (3):
                    products = productService.GetAll()
                            .OrderBy(model => model.Product_Price).ToList();
                    break;
                case (4):
                    products = productService.GetAll()
                            .OrderByDescending(model => model.Product_Price).ToList();
                    break;
                default:
                    products = productService.GetAll();
                    break;
            }
            return products;
        }
        public IActionResult Index(ProductFilterItems filterItems)
        {
            var pageNumber = filterItems.page ?? 1;
            int pageSize = 16;

            if (filterItems.CatID != null)
            {
                var products = categoryService.GetByID(filterItems.CatID).Products.ToPagedList(pageNumber, pageSize);
                ViewBag.CatID = filterItems.CatID;
                ViewBag.Categories = categoryService.GetAll();
                ViewBag.Tags = tagsService.GetAll();
                return View(products);
            }
            else if (filterItems.PriceID != null)
            {
                var products = filterService.FilterByPrice(filterItems.PriceID).ToPagedList(pageNumber, pageSize);
                ViewBag.PriceID = filterItems.PriceID;
                ViewBag.Categories = categoryService.GetAll();
                ViewBag.Tags = tagsService.GetAll();
                return View(products);
            }
            else if (filterItems.TagID != null)
            {
                var products = filterService.FilterByTags(filterItems.TagID).ToPagedList(pageNumber, pageSize);
                ViewBag.TagID = filterItems.PriceID;
                ViewBag.Categories = categoryService.GetAll();
                ViewBag.Tags = tagsService.GetAll();
                return View(products);
            }
            else if (filterItems.searchName != null)
            {
                var products = filterService.FilterByName(filterItems.searchName).ToPagedList(pageNumber, pageSize);
                ViewBag.searchName = filterItems.searchName;
                ViewBag.Categories = categoryService.GetAll();
                ViewBag.Tags = tagsService.GetAll();
                return View(products);
            }
            else if (filterItems.SortID != null)
            {
                var products = SortingItems(filterItems.SortID).ToPagedList(pageNumber, pageSize);
                ViewBag.SortID = filterItems.SortID;
                ViewBag.Categories = categoryService.GetAll();
                ViewBag.Tags = tagsService.GetAll();
                return View(products);
            }
            ViewBag.Categories = categoryService.GetAll();
            ViewBag.Tags = tagsService.GetAll();
            return View(productService.GetAll().ToPagedList(pageNumber , pageSize));
        }
        public IActionResult Details(int id)
        {
            Product product = productService.GetByID(id);

            ViewBag.RelatedProducts = productService.GetAll()
                .Where(model => model.Category_ID == product.Category_ID)
                .Take(8).ToList();

            return View(product);
        }
        [Authorize]
        public async Task<IActionResult> AddWishList(int id)
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            Product product = productService.GetByID(id);

            foreach (var item in wishListService.GetAll())
            {
                if (item.Product_ID == product.Product_ID)
                {
                    return RedirectToAction("Index");
                }
            }
            UserWishList userWishList = new UserWishList
            {
                Customer_ID = user.Id,
                Product_ID = product.Product_ID
            };
            wishListService.Add(userWishList);
            return RedirectToAction("UserWishList");
        }
        [Authorize]
        public async Task<IActionResult> UserWishList()
        {
            var user = await userManager.FindByEmailAsync(User.Identity.Name);
            var wishlist = wishListService.GetAll()
                .Where(model => model.Customer_ID == user.Id).ToList();

            return View(wishlist);
        }
        [Authorize]
        // id =============> UserWishList ID
        public IActionResult DeleteFromWishList(int id)
        {
            wishListService.Delete(id);
            return RedirectToAction("UserWishList");
        }

    }
}
