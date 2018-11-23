using ShoppingCartDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models.ViewModel
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}