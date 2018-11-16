using System.Collections.Generic;

namespace ShoppingCartDemo.Models
{
    public interface ITotalCalculator
    {
        decimal CartTotal(IEnumerable<ProductView> products);
    }
}