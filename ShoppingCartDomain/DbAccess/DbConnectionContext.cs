using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingCartDomain.Entities;
using System.Data.Entity;

namespace ShoppingCartDomain.DbAccess
{
    public class DbConnectionContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
