using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class StructureMapWebApiControllerActivator : IHttpControllerActivator
    {
        private readonly Func<IContainer> _container;

        public StructureMapWebApiControllerActivator(Func<IContainer> container)
        {
            _container = container;
        }

        public IHttpController Create(
            HttpRequestMessage request,
            HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            var nested = _container().GetNestedContainer();
            var instance = nested.GetInstance(controllerType) as IHttpController;
            request.RegisterForDispose(nested);
            return instance;
        }
    }
}