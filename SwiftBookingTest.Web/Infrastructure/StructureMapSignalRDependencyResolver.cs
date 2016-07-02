using Microsoft.AspNet.SignalR;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class StructureMapSignalRDependencyResolver : DefaultDependencyResolver
    {
        private readonly Func<IContainer> _container;

        public StructureMapSignalRDependencyResolver(Func<IContainer> container)
        {
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            var container = _container();
            return container.TryGetInstance(serviceType) ?? base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            var container = _container();
            var objects = container.GetAllInstances(serviceType).Cast<object>();
            return objects.Concat(base.GetServices(serviceType));
        }
    }
}