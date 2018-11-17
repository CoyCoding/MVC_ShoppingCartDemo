using System.Collections.Generic;

namespace ShoppingCartDemo.Models
{
    public interface ITotalCalculator
    {
        decimal CartTotal(ProductListViewModel products);
    }
}