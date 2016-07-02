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
using System.Web.Mvc;

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
                //c.AddRegistry(new WebApiActionFilterRegistry(
                //    () => container ?? ObjectFactory.Container));

                c.Policies.SetAllProperties(x =>
                    x.Matching(p =>
                        p.DeclaringType.CanBeCastTo(typeof(System.Web.Http.Filters.ActionFilterAttribute)) &&
                        p.DeclaringType.Namespace.StartsWith("SwiftBookingTest") &&
                        !p.PropertyType.IsPrimitive &&
                        p.PropertyType != typeof(string)));

            });


            config.Services.Replace(
                typeof(IHttpControllerActivator),
                new StructureMapWebApiControllerActivator(container));

            //var providers = config.Services.GetFilterProviders().ToList();
            //config.Services.Add(typeof(System.Web.Http.Filters.IFilterProvider),
            //    new WebApiFilterProvider(() => container ?? ObjectFactory.Container));
            //var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            //config.Services.Remove(typeof(System.Web.Http.Filters.IFilterProvider), defaultprovider);

            config.Services.Replace(typeof(System.Web.Http.Filters.IFilterProvider),
                new WebApiFilterProvider(container));

        }

    }
}