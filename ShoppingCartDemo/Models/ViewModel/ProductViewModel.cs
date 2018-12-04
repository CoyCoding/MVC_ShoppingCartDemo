using ShoppingCartDomain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartDemo.Models.ViewModel
{
    public class ProductViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int CategoryId { get; set; }

        public string Seller { get; set; }


        public ProductViewModel()
        {
            Id = 0;
        }
        
        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Quantity = product.Quantity;
            CategoryId = product.CategoryId;
            Seller = product.Seller;
        }

    }
}