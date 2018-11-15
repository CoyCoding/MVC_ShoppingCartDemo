using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models.CartCalculator
{
    public class CartDiscount : ICartDiscount
    {
        public decimal Applydiscount(decimal cartTotal)
        {
            if (cartTotal >= 100)
            {
                return (cartTotal - (5m / 100m * cartTotal));
            }
            else
            {
                return cartTotal;
            }
        }
    }
}