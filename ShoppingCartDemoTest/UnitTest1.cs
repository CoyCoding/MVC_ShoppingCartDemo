using System;
using ShoppingCartDemo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCartDemo.Models.CartCalculator;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class UnitTest1
    {
        public ICartDiscount GetCartDiscount()
        {
            return new CartDiscount();
        }

        [TestMethod]
        public void TestCartDiscount()
        {
            //arrange
            ICartDiscount testCart = GetCartDiscount();
            decimal testTotal = 100m;

            //act
            var discountedTotal = testCart.Applydiscount(testTotal);

            //assert
            Assert.AreEqual(testTotal * .95m, discountedTotal);
            
        }
    }
}
