using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemo.Controllers
{
    public class HomeController : Controller
    {
        //private ITotalCalculator calculator;
        private IProductRepo _productRepo;

        public HomeController(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        //private Product[] tempCart =
        //{
        //    new Product{Name ="Ball", Price =  2.50m, Category = "toy"},
        //    new Product{Name = "Chips", Price = 2.50m, Category = "food"},
        //    new Product{Name = "Game", Price = 20.20m, Category="toy"},
        //    new Product{Name = "Game", Price = 20.20m, Category="toy"},
        //};

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View(_productRepo.Products);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}