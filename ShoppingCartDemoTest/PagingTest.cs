using Moq;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDomain.Entities;
using ShoppingCartDomain.DbAccess;
using ShoppingCartDemo.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class PagingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            Mock<IProductRepo> mockObj = new Mock<IProductRepo>();
            mockObj.Setup(m => m.Products).Returns(new Product[]
            {
                new Product {id = 1, Name = "Item 1"},
                new Product {id = 2, Name = "Item 2"},
                new Product {id = 3, Name = "Item 3"},
                new Product {id = 4, Name = "Item 4"},
                new Product {id = 5, Name = "Item 5"},
                new Product {id = 6, Name = "Item 6"}
            });

            HomeController controller = new HomeController(mockObj.Object, 2);
            //Act
            IEnumerable<Product> result = (IEnumerable<Product>)controller.About(2).Model;
            
            //Assert
            
            Product[] productArr = result.ToArray();
            Console.WriteLine(productArr);
            Assert.IsTrue(productArr.Length == 2);
            Assert.AreEqual(productArr[0].Name, "Item 3");
        }
    }
}
