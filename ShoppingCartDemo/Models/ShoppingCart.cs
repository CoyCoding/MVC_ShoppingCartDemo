using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class ShoppingCart 
    {
        private ITotalCalculator _calculator;

        public IEnumerable<ProductView> Products { get; set; }

        public ShoppingCart(ITotalCalculator calculator)
        {
            _calculator = calculator;
        }

        public decimal CalculateProductTotal()
        {
            return _calculator.CartTotal(Products);
        }

    }
}