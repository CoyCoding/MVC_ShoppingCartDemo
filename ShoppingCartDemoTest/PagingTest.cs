using Moq;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using ShoppingCartDomain.Entities;
using ShoppingCartDomain.DbAccess;
using ShoppingCartDemo.Models.HtmlHelpers;
using ShoppingCartDemo.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class PagingTest
    {
        [TestMethod]
        public void Can_Page()
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

        [TestMethod]
        public void Generates_Page_Links()
        {
            //Arrange
            HtmlHelper htmlHelper = null;

            Pagination pagingInfo = new Pagination
            {
                CurrentPage = 2,
                TotalItems = 21,
                ItemsPerPage = 10
            };

            Func<int, string> pageUrlDel = num => "Page" + num;

            //Act
            MvcHtmlString result = htmlHelper.PaginationLinks(pagingInfo, pageUrlDel);

            //Assert
            Assert.AreEqual(@"<a class=""btn btn-default"" href=""Page1"">1</a>"
                          + @"<a class=""btn btn-default btn-primary selected"" href=""Page2"">2</a>"
                          + @"<a class=""btn btn-default"" href=""Page3"">3</a>",
                          result.ToString());
        }
    }
}
