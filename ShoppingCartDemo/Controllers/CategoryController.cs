using System;
using System.Collections.Generic;
using ShoppingCartDomain.Entities;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDemo.Models.ViewModel;

namespace ShoppingCartDemo.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _productRepo;
        private ICategoryViewModel _categories;
        // GET: Category

        public CategoryController()
        {    
            _productRepo = new ApplicationDbContext();
            _categories = new CategoryViewModel
            {
                Categories = _productRepo.Categories
                .Select(cat => cat.Name)
                .Distinct()
                .OrderBy(x => x)
            };
        }

        protected override void Dispose(bool disposing)
        {
            _productRepo.Dispose();
        }
        public PartialViewResult Menu(string category = null)
        {
            _categories.CurrentCategory = category;        

            return PartialView(_categories);
        }
    }
}