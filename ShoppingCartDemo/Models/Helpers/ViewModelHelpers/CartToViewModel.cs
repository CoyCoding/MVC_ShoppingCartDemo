using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoppingCartDemo.Models.ViewModel;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemo.Models.Helpers.ViewModelHelpers
{
    public static class CartToViewModel
    {
        public static CartIndexViewModel ConvertToViewModel(this Cart cart)
        {
            CartIndexViewModel tempCart = new CartIndexViewModel();
            foreach(var item in cart.GetCartItems)
            {
                tempCart.Cart.AddItem(item.Product, item.Quantity);
            }
            return tempCart;
        }
    }
}