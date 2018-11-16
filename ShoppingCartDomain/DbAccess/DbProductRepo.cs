using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDomain.DbAccess
{
    public class DbProductRepo : IProductRepo
    {
        private DbConnectionContext _context = new DbConnectionContext();

        public  IEnumerable<Product> Products
        {
            get { return _context.Products; }
        }
    }

}
