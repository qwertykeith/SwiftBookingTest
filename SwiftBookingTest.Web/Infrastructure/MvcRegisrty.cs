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

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcRegisrty: Registry
    {
        public MvcRegisrty()
        {
            For<IIdentity>().Use(() => HttpContext.Current.User != null
            ? HttpContext.Current.User.Identity
            : null);

            //UseDO:Create Interface for dbcontext and bind Use that
            //For<SwiftDemoContext>().Use(new SwiftDemoContext());

            //For<ILogger>().Use(ctx => (ILogger)ctx.Kernel.Get<ILogger>());

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
        }
    }
}