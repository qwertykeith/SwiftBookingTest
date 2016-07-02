using StructureMap;
using StructureMap.TypeRules;
using SwiftBookingTest.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web
{
    public static class StructureMapWebApiConfig
    {
        public static void RegisterStructureMapForWebApi(HttpConfiguration config)
        {
            Container container = new Container();

            container.Configure(c =>
            {
                c.AddRegistry<StandardRegisrty>();
                c.AddRegistry<WebApiRegistry>();
                c.AddRegistry(new WebApiActionFilterRegistry(
                    () => container ?? ObjectFactory.Container));
            });

            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapWebApiControllerActivator(container));
            
            config.Services.Replace(typeof(IFilterProvider),
                new WebApiFilterProvider(container));
        }

    }
}