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

        [Required(ErrorMessage = "Please enter a Product Name")]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Please enter a Description")]
        public string Description { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a vaild price")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a Quantity in Stock")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Please enter a Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a Seller")]
        public string Seller { get; set; }

        public int ImageId { get; set; }

        public byte[] ImageData { get; set; }

        public string ImageType { get; set; }

        public ProductViewModel()
        {
            
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
            ImageData = product.Image.ImageData;
            ImageType = product.Image.ImageType;
        }

        public Product ConvertToProduct()
        {
            Product returnProduct = new Product
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                Quantity = Quantity,
                CategoryId = CategoryId,
                Seller = Seller,
                Image = new Image()
            };
            return returnProduct;
        }
    }
}