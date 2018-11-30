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
        private IApplicationDbContext _productRepo;
        private ICategoryViewModel _categories;

        // GET: Category
        public CategoryController(IApplicationDbContext productRepo)
        {    
            _productRepo = productRepo;
            _categories = new CategoryViewModel
            {
                Categories = _productRepo.Categories
                .Select(cat => cat.Name)
                .Distinct()
                .OrderBy(x => x)
            };
        }

        public PartialViewResult _Menu(string category = null)
        {
            _categories.CurrentCategory = category;        

            return PartialView(_categories);
        }
    }
}