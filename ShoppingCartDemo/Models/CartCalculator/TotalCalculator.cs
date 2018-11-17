using ShoppingCartDemo.Models.CartCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class TotalCalculator : ITotalCalculator
    {
        private ICartDiscount _discount;

        /// <summary>
        /// Constructor for TotalCalculator N-Inject 
        /// </summary>
        public TotalCalculator(ICartDiscount discountParam)
        {
            _discount = discountParam;
        }

        /// <summary>
        /// Method for finding total of all products in Ienum<Product>
        /// </summary>
        /// <returns>Sum of product prices and applies any discounts</returns>
        public decimal CartTotal(ProductListViewModel products)
        {
            return _discount.Applydiscount(products.Products.Sum(p => p.Price));
        }
    }
}