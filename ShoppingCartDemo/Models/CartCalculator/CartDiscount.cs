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
            return (cartTotal - (10m / 100m * cartTotal));
        }
    }
}