using StructureMap;
using SwiftBookingTest.Core;
using SwiftBookingTest.Core.BusinessEngine;
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcRegistry : Registry
    {
        public MvcRegistry()
        {
            //Get repository
            For<RepositoryFactories>().Use<RepositoryFactories>()
                .Ctor<IDictionary<Type, Func<DbContext, object>>>("factories")
                .Is(new Dictionary<Type, Func<DbContext, object>>());
            For<IRepositoryProvider>().Use<RepositoryProvider>();
            //get business engine
            For<IBusinessEngineFactory>().Use<BusinessEngineFactory>().Ctor<Dictionary<Type, object>>("businessEngine")
                .Is(new Dictionary<Type, object>());
            For<ISwiftBookingBusinessEngineUow>().Use<SwiftBookingBusinessEngineUow>();
            //Create Unit of work for SwiftDemo
            For<ISwiftDemoUow>().Use<SwiftDemoUow>();

            For<BundleCollection>().Use(BundleTable.Bundles);
            For<RouteCollection>().Use(RouteTable.Routes);
            For<IIdentity>().Use(() => HttpContext.Current.User.Identity);
            For<HttpSessionStateBase>()
                .Use(() => new HttpSessionStateWrapper(HttpContext.Current.Session));
            For<HttpContextBase>()
                .Use(() => new HttpContextWrapper(HttpContext.Current));
            For<HttpServerUtilityBase>()
                .Use(() => new HttpServerUtilityWrapper(HttpContext.Current.Server));

         
        }
    }
}