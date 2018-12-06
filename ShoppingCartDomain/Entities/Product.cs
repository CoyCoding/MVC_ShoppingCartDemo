using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingCartDomain.Entities
{
    public class Product
    {

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


        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Please enter a Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please enter a Seller")]
        public string Seller { get; set; }

        public virtual ICollection<Image> Images { get; set; }
        }
    }

