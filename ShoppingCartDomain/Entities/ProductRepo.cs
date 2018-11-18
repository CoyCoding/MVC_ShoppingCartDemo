using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDomain.Entities
{
    public class ProductRepo : IProductRepo
    {
       public IEnumerable<Product> Products { get; set; }

       public IEnumerable<Category> Categories { get; set; }
    }
}
