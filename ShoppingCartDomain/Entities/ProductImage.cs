using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDomain.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        public string ImageDescription { get; set; }

        // Navigation Prop
        public Product Product { get; set; }

        //FK
        public int ProductId { get; set; }
    }
}
