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
            //Mock - create order processor
            //     - create empty cart
            //     - create instance of the cart controller for testing
            Mock<IOrderProcessor> mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            CartController cartController = new CartController(null, mock.Object);

            //Act - collect the result from the Checkout Action
            ViewResult result = cartController.Checkout(cart, new ShippingDetails());

            //Assert - check that an empty cart will not be processed
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            //Assert - check that the method returns default
            Assert.AreEqual("", result.ViewName);
            //Assert - check that the model was invalid
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);

        }

        [TestMethod]
        public void Can_Checkout_And_Submit_Order()
        {
            //Arrange
            //Mock - create order processor
            //     - create cart with one item
            //     - create instance of the cart controller for testing
            var mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            CartController target = new CartController(null, mock.Object);

            //Act - checkout with simulated error
            ViewResult result = target.Checkout(cart, new ShippingDetails());

            //Assert - order not passed because Shipping Details error
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Once());
            //Assert - default view is returned
            Assert.AreEqual("Complete", result.ViewName);
            //Assert - check that the model was invalid
            Assert.AreEqual(true, result.ViewData.ModelState.IsValid);
        }

        [TestMethod]
        public void  Cannot_Checkout_Invaild_ShippingDetails()
        {
            //Arrange
            //Mock - create order processor
            //     - create cart with one item
            //     - create instance of the cart controller for testing
            var mock = new Mock<IOrderProcessor>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            CartController target = new CartController(null, mock.Object);
            target.ModelState.AddModelError("error", "error");

            //Act - checkout with simulated error
            ViewResult result = target.Checkout(cart, new ShippingDetails());

            //Assert - order not passed because Shipping Details error
            mock.Verify(m => m.ProcessOrder(It.IsAny<Cart>(), It.IsAny<ShippingDetails>()), Times.Never());
            //Assert - default view is returned
            Assert.AreEqual("", result.ViewName);
            //Assert - check that the model was invalid
            Assert.AreEqual(false, result.ViewData.ModelState.IsValid);

        }
    }
}
