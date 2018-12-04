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

            public string Name { get; set; }

            [DataType(DataType.MultilineText)]
            public string Description { get; set; }

            public decimal Price { get; set; }

            public int Quantity { get; set; }

            public Category Category { get; set; }

            public int CategoryId { get; set; }

            public string Seller { get; set; }
        }
    }

