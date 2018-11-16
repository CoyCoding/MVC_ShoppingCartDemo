using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using Moq;
using ShoppingCartDomain.Entities;
using Ninject;
using ShoppingCartDemo.Models.CartCalculator;

namespace ShoppingCartDemo.DependencyInject
{
    public class NinjectDIResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDIResolver(IKernel kernelPeram)
        {
            kernel = kernelPeram;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<ITotalCalculator>().To<TotalCalculator>();
            kernel.Bind<ICartDiscount>().To<CartDiscount>();

            Mock<IProductRepo> mock = new Mock<IProductRepo>();

            mock.Setup(obj => obj.Products).Returns(new List<Product>
            {
                new Product{ Name = "Food", Price = 2m},
                new Product{ Name = "Game", Price = 50m},
                new Product{ Name = "Clothes", Price = 20m}
            });

            kernel.Bind<IProductRepo>().ToConstant(mock.Object);
        }

    }
}