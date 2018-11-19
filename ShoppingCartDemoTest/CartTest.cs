using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartDomain.Entities;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void Can_Add_Items()
        {
            //Arrange 
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };

            //Arrange
            Cart cart = new Cart();

            //Act
            cart.AddItem(p1, 1);
            CartItem[] list = cart.GetCartItems.ToArray();
            //Assert
            Assert.AreEqual(list[0].Product, p1);
            //Act
            cart.RemoveSingleItem(p1);
            Assert.AreEqual(cart.CartValueTotal(), 0);
            
            

        }
    }
}
