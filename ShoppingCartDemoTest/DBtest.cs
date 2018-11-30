using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingCartDomain.Entities;
using Moq;
using System.Linq;
using ShoppingCartDemo.Controllers;
using ShoppingCartDemo.Models;
using System.Data.Entity;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class DBtest
    {
        [TestMethod]
        public void Store_View_test()
        {

        }

        [TestMethod]
        public void test_Iapplicationdbcontext() { 
            var mockSet = new Mock<DbSet<Product>>();

            var productList = new Product[]
            {
                new Product { Id = 1, Name = "Item 1" },
                new Product { Id = 2, Name = "Item 2" },
                new Product { Id = 3, Name = "Item 3" },
                new Product { Id = 4, Name = "Item 4" },
                new Product { Id = 5, Name = "Item 5" },
                new Product { Id = 6, Name = "Item 6" }
            };

            mockSet.Object.AddRange(productList);
                //Arrange
            var mockObj = new Mock<IApplicationDbContext>();
            mockObj.Setup(m => m.Products).Returns(mockSet.Object);

            var testobject = mockObj.Object.Products.Select(p => p.CategoryId == 1);

            Assert.AreEqual(mockObj.Object.Products.Select(p => p.CategoryId == 1), productList[0]);
            
        }
    }
    
}
