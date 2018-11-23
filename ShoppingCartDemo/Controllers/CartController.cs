using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDemo.Models.HtmlHelpers;
using ShoppingCartDemo.Models.ViewModel;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemo.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _productRepo;
        // GET: Cart
        public CartController()
        {
            _productRepo = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _productRepo.Dispose();
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(int Id, string returnUrl)
        {
            Product product = GetProductToAdd(Id);

            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl} );
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int Id, string returnUrl)
        {
            Product product = GetProductToAdd(Id);

            if(product != null)
            {
                GetCart().RemoveSingleItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });

        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        private Product GetProductToAdd(int productId)
        {
            return _productRepo.Products.FirstOrDefault(p => p.Id == productId);
        }
    }
}