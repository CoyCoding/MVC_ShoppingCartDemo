using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ShoppingCartDomain.Entities;
using Moq;
using System.Linq;

namespace ShoppingCartDemoTest
{
    [TestClass]
    public class DBtest
    {
        [TestMethod]
        public void Store_View_test()
        {
            //arrange
            Mock<IProductRepo> mockObj = new Mock<IProductRepo>();
            mockObj.Setup(m => m.Products).Returns(
                new Product[]
                {
                    new Product {Id = 1, Name = "Item 1", CategoryId=1},
                    new Product {Id = 2, Name = "Item 2", CategoryId=1},
                    new Product {Id = 3, Name = "Item 3", CategoryId=3},
                    new Product {Id = 4, Name = "Item 4", CategoryId=1},
                    new Product {Id = 5, Name = "Item 5", CategoryId=2},
                    new Product {Id = 6, Name = "Item 6", CategoryId=1}
                });

            mockObj.Setup(m => m.Categories).Returns(
                new Category[]
                {
                    new Category {Id =1, Name="test1"},
                    new Category {Id =2, Name="test2"},
                    new Category {Id =3, Name="test3"},
                });
            var _PageSize = 5;
            var category = "test1";
            var page = 1;

            //act
            var _productRepo = mockObj.Object;
            var Item1 = _productRepo.Products.SingleOrDefault(p => p.Id == 1).Name;
            var Products = _productRepo.Products
                    .Where(p => category == null || p.CategoryId == _productRepo.Categories.FirstOrDefault(c => c.Name == category).Id)
                    .OrderBy(p => p.Id)
                    .Skip((page - 1) * _PageSize)
                    .Take(_PageSize);

            //assert
            Assert.AreEqual(Item1, mockObj.Object.Products.ToList()[0].Name);
            Assert.AreEqual(4, Products.Count());

           

            //    PagingInfo = new Pagination
            //    {
            //        CurrentPage = page,
            //        ItemsPerPage = _PageSize,
            //        TotalItems = category == null ?
            //        _productRepo.Products.Count() :
            //        _productRepo.Products.Where(p => p.CategoryId == currentCategory.Id).Count()
            //    },

            //    CurrentCategory = currentCategory?.Name
            //};

        }
    }
    
}
