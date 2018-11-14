using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;

namespace ShoppingCartDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IEnumerable<Product> products = new ShoppingCart
            {
                Products = new List<Product> {
                    new Product{Name ="Ball", Price =  2.50m, Category = "toy"},
                    new Product{Name = "Chips", Price = 2.50m, Category = "food"},
                    new Product{Name = "Game", Price = 20.20m, Category="toy"},
                }
            };

            return View(products);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}