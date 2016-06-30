using StructureMap;
using SwiftBookingTest.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;

namespace SwiftBookingTest.Web
{
    public static class StructureMapConfig
    {
        public static void RegisterStructureMapForWebApi(HttpConfiguration config)
        {
            Container container = new Container();

            container.Configure(c =>
            {
                c.AddRegistry<StandardRegisrty>();
                c.AddRegistry<WebApiRegistry>();
            });

            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapWebApiControllerActivator(container));

        }

        public static void RegisterStructureMapForMvc()
        {

        }
    }
}