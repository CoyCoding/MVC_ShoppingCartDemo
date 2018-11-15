using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCartDemo.Models;
using Ninject;

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
        }

        private static void RegisterServices (IKernel kernel)
        {
            System.Web.Mvc.DependencyResolver.SetResolver(new
                ShoppingCartDemo.DependencyInject.NinjectDIResolver(kernel));
        }
    }
}