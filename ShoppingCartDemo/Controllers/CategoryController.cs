using System;
using System.Collections.Generic;
using ShoppingCartDomain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;

namespace ShoppingCartDemo.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _productRepo;
        // GET: Category

        public CategoryController()
        {
            _productRepo = new ApplicationDbContext();
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = _productRepo.Categories
                .Select(cat => cat.Name)
                .Distinct()
                .OrderBy(x => x);

            return PartialView(categories);
        }
    }
}