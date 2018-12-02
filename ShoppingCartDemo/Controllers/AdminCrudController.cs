using ShoppingCartDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Controllers
{
    public class AdminCrudController : Controller
    {
        IApplicationDbContext _ProductRepo;

        public AdminCrudController(IApplicationDbContext productRepo)
        {
            _ProductRepo = productRepo;
        }

        // GET: AdminCrud
        public ActionResult Index()
        {
            return View(_ProductRepo.Products);
        }
    }
}