using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Graph;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Core;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Core.BusinessEngine;
using SwiftBookingTest.Core.Helpers;
using System.Data.Entity;
using System.Security.Principal;
using System.Web.Optimization;
using System.Web.Routing;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcRegisrty: Registry
    {
        public MvcRegisrty()
        {
            For<BundleCollection>().Use(BundleTable.Bundles);
            For<RouteCollection>().Use(RouteTable.Routes);
            
            For<HttpSessionStateBase>()
                .Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<HttpContextBase>()
                .Use(() => new HttpContextWrapper(HttpContext.Current));
            For<HttpServerUtilityBase>()
                .Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));

            For<IIdentity>().Use(() => HttpContext.Current.User != null
            ? HttpContext.Current.User.Identity
            : null);

            For<RepositoryFactories>().Use<RepositoryFactories>()
                .Ctor<IDictionary<Type, Func<DbContext, object>>>().
                Is(new Dictionary<Type, Func<DbContext, object>>()).Singleton();

            For<IRepositoryProvider>().Use<RepositoryProvider>();

            For<IBusinessEngineFactory>().Use<BusinessEngineFactory>().
               Ctor<Dictionary<Type, object>>().Is(new Dictionary<Type, object>());

            For<ISwiftBookingBusinessEngineUow>().Use<SwiftBookingBusinessEngineUow>();

            For<ISwiftDemoUow>().Use<SwiftDemoUow>();
        }
    }
}