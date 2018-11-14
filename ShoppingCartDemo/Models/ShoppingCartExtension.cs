using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public static class ShoppingCartExtension
    {
        public static decimal CartTotal(this IEnumerable<Product> productList)
        {
            decimal total = 0;
            foreach(Product product in productList)
            {
                total += product.Price;
            }
            return total;
        }
    }
}