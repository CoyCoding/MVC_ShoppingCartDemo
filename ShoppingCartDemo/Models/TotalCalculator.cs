using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class TotalCalculator : ITotalCalculator
    {
        public decimal CartTotal(IEnumerable<Product> products)
        {
            return products.Sum(p => p.Price);
        }
    }
}