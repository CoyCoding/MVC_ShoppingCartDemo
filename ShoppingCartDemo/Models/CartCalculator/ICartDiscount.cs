using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDemo.Models.CartCalculator
{
    public interface ICartDiscount
    {
        decimal Applydiscount(decimal cartTotal);
    }
}
