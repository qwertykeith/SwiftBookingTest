using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using StructureMap.Graph;
using System.Security.Principal;
using SwiftBookingTest.Core;
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Core.BusinessEngine;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using System.Data.Entity;
using SwiftBookingTest.Core.Repository;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class WebApiRegistry : Registry
    {
        public WebApiRegistry()
        {
            For<IIdentity>().Use(() => Getidentity());

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            For<RepositoryFactories>().Use<RepositoryFactories>()
                .Ctor<IDictionary<Type, Func<DbContext, object>>>().
                Is(new Dictionary<Type, Func<DbContext, object>>()).Singleton();

            For<IRepositoryProvider>().Use<RepositoryProvider>();

            For<IBusinessEngineFactory>().Use<BusinessEngineFactory>().
               Ctor<Dictionary<Type, object>>().Is(new Dictionary<Type, object>());

            For<ISwiftBookingBusinessEngineUow>().Use<SwiftBookingBusinessEngineUow>();

            For<ISwiftDemoUow>().Use<SwiftDemoUow>();

            For<ILogger>().Use<Logger>();

            For<HttpSessionStateBase>()
                .Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<HttpContextBase>()
                .Use(() => new HttpContextWrapper(HttpContext.Current));
            For<HttpServerUtilityBase>()
                .Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));

        }

        private static IIdentity Getidentity()
        {
            HttpContext.Current.User = new GenericPrincipal(new GenericIdentity("atul221282@gmail.com"), new string[] { /* fill roles if any */ });
            return HttpContext.Current.User.Identity;
        }

    }
}