using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDemo.Models.HtmlHelpers;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemo.Controllers
{
    public class HomeController : Controller
    {
        //private ITotalCalculator calculator;
        //private IProductRepo _productRepo;
        private ApplicationDbContext  _productRepo;
        private int _PageSize = 4;

        public HomeController(int pageSize = 4)
        {
            _productRepo = new ApplicationDbContext();
            _PageSize = pageSize;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Store(int page = 1)
        {
           
            var productList = new ProductListViewModel
            {
                Products = _productRepo.Products
                .OrderBy(p => p.Id)
                .Skip((page - 1) * _PageSize)
                .Take(_PageSize),

                PagingInfo = new Pagination
                {
                    CurrentPage = page,
                    ItemsPerPage = _PageSize,
                    TotalItems = _productRepo.Products.Count()
                }
            };

            return View(productList);
               
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}