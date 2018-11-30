using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingCartDemo.Controllers;
using ShoppingCartDomain.Abstract;
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
            Assert.AreEqual(cart.GetCartItems.Any(), false);
        }

        [TestMethod]
        public void Does_Increase_Quantity()
        {
            //Arrange
            Product p1 = new Product { Id = 1, Name = "P1" };
            Product p2 = new Product { Id = 2, Name = "P2" };

            Cart cart = new Cart();

            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 10);
            CartItem[] list = cart.GetCartItems.OrderBy(c => c.Product.Id).ToArray();

            Assert.AreEqual(list.Length, 2);
            Assert.AreEqual(list[0].Quantity, 11);
            Assert.AreEqual(list[1].Quantity, 1);
        }

        [TestMethod]
        public void Calculate_Cart_Total()
        {
            Product p1 = new Product { Id = 1, Name = "P1", Price = 100m};
            Product p2 = new Product { Id = 2, Name = "P2", Price = 100m };

            Cart cart = new Cart();

            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 2);

            Assert.AreEqual(cart.CartValueTotal(), 400m);

        }

        [TestMethod]
        public void Cannot_Checkout_Empty_Cart()
        {
            //Arrange Test
            //Mock- create order processor
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            //Mock - create empty cart
            Cart cart = new Cart();
            //Mock - create shipping Details
            ShippingDetails shippingDetails = new ShippingDetails();
            //Create instance of the cart controller for testing
            CartController cartController = new CartController(null, mock.Object);

            //Act - collect the result from the Checkout Action
            ViewResult result = cartController.Checkout(cart, shippingDetails);

            //Assert - check that an empty cart will not be processed
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            //Assert - check that the method returns default
            Assert.AreEqual("", result.ViewName);
            //Assert - check that the model was invalid
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);

        }
    }
}
