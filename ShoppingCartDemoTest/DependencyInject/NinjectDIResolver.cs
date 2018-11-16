using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using ShoppingCartDomain.Entities;
using Ninject;

namespace ShoppingCartDemo.UnitTest.DependencyInject
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
            //add bindings
        }

    }
}