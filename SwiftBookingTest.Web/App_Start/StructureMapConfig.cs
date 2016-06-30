using StructureMap;
using SwiftBookingTest.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace SwiftBookingTest.Web
{
    public static class StructureMapConfig
    {
        public static void RegisterStructureMapForWebApi(HttpConfiguration config)
        {
            Container container = new Container(c => c.AddRegistry<WebApiRegistry>());
            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapWebApiControllerActivator(container));
        }
    }
}