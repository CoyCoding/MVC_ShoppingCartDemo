using System;
using System.Collections.Generic;
using ShoppingCartDomain.Entities;
using ShoppingCartDemo.Models.HtmlHelpers;
using System.Linq;
using System.Web;

namespace ShoppingCartDemo.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public Pagination PagingInfo { get; set; }
    }
}