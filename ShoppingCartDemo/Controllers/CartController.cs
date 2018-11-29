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
        private IApplicationDbContext _productRepo;
        
        // GET: Cart
        public CartController(IApplicationDbContext productRepo)
        {
            _productRepo = productRepo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl)
        {
            Product product = GetProductToAdd(Id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new { returnUrl} );
        }

        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl)
        {
            Product product = GetProductToAdd(Id);

            if(product != null)
            {
                cart.RemoveSingleItem(product);
            }

            return RedirectToAction("Index", new { returnUrl });

        }

        [HttpPost]
        public RedirectToRouteResult RemoveAllFromCart(Cart cart, string returnUrl)
        {
            cart.Clear();

            return RedirectToAction("Index", new { returnUrl });
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        private Product GetProductToAdd(int productId)
        {
            return _productRepo.Products.FirstOrDefault(p => p.Id == productId);
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}