using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartDomain.Entities
{
    public class Cart
    {
        private List<CartItem> productCollection = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            CartItem cartItem = productCollection
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if(cartItem == null)
            {
                productCollection.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveSingleItem(Product product)
        {
            int itemIndex = productCollection.FindIndex(item => item.Product.Id == product.Id);
            if (itemIndex >= 0)
            {
                if (--productCollection.ToList()[itemIndex].Quantity == 0)
                {
                    productCollection.RemoveAt(itemIndex);
                }
            }
        }

        public decimal CartValueTotal()
        {
            return productCollection.Sum(cart => cart.Product.Price * cart.Quantity);
        }

        public void Clear()
        {
            productCollection.Clear();
        }

        public IEnumerable<CartItem> GetCartItems
        {
            get { return productCollection; }
        }
    }
}
