using ShoppingCartDemo.Models;
using ShoppingCartDemo.Models.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Controllers
{
    public class AdminCrudController : Controller
    {
        IApplicationDbContext _productRepo;
        private int _PageSize;

        public AdminCrudController(IApplicationDbContext productRepo, int pageSize = 12)
        {
            _productRepo = productRepo;
            _PageSize = pageSize;
        }

        // GET: AdminCrud
        public ActionResult Index(string category, int page = 1)
        {
            var currentCategory = _productRepo.Categories.SingleOrDefault(c => c.Name == category);

            if (category != null && currentCategory == null)
            {
                return View("Index");
            }

            var productList = new ProductListViewModel
            {
                Products = _productRepo.Products
                .Where(p => category == null || p.CategoryId == _productRepo.Categories.FirstOrDefault(c => c.Name == category).Id)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * _PageSize)
                .Take(_PageSize),

                PagingInfo = new Pagination
                {
                    CurrentPage = page,
                    ItemsPerPage = _PageSize,
                    TotalItems = category == null ?
                    _productRepo.Products.Count() :
                    _productRepo.Products.Where(p => p.CategoryId == currentCategory.Id).Count()
                },

                CurrentCategory = currentCategory?.Name
            };
            var test = productList.Products.Count();
            return View(productList);
        }

        public ActionResult Edit()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Delete()
        {
            return View();
        }
    }
}