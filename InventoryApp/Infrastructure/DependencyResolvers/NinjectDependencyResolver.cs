using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Ninject;

namespace InventoryApp.Infrastructure.DependencyResolvers
{
    public class NinjectDependencyResolver : IDependencyResolver
    {

        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;

            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }


        private void AddBindings()
        {
            // Add any bindings in here
        }


        private IKernel _kernel;
    }
}