using System;
using System.Collections.Generic;
using System.Web.Mvc;
using StructureMap;
using System.Linq;

namespace SwiftBookingTest.Web.Infrastructure
{
    internal class StructureMapMVCDependencyResolver : IDependencyResolver
    {
        private readonly Func<IContainer> _factory;

        public StructureMapMVCDependencyResolver(Func<IContainer> p)
        {
            _factory = p;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            var factory = _factory();

            return serviceType.IsAbstract || serviceType.IsInterface
                ? factory.TryGetInstance(serviceType)
                : factory.GetInstance(serviceType);
        }
       
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _factory().GetAllInstances(serviceType).Cast<object>();
        }
    }
}