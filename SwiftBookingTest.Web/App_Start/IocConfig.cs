using System.Web.Http;
using SwiftBookingTest.Core;
using SwiftBookingTest.CoreContracts;
using Ninject;
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Core.BusinessEngine;
using System.Collections.Generic;
using System;
using SwiftBookingTest.Web.Filters;
using System.Web.Http.Filters;
using Ninject.Activation;
using Ninject.Modules;

namespace SwiftBookingTest.Web
{
    public class IocConfig
    {
        public static void RegisterIoc(HttpConfiguration config)
        {
            var kernel = new StandardKernel(); // Ninject IoC
            
            //TODO:Create Interface for dbcontext and bind to that
            kernel.Bind<SwiftDemoContext>().ToSelf();

            kernel.Bind<ILogger>().ToMethod(ctx => (ILogger)ctx.Kernel.Get<ILogger>());

            // These registrations are "per instance request".
            // See http://blog.bobcravens.com/2010/03/ninject-life-cycle-management-or-scoping/

            kernel.Bind<RepositoryFactories>().To<RepositoryFactories>()
                .InSingletonScope();

            kernel.Bind<IRepositoryProvider>().To<RepositoryProvider>();

            kernel.Bind<ISwiftBookingBusinessEngineUow>().To<SwiftBookingBusinessEngineUow>();

            kernel.Bind<ISwiftDemoUow>().To<SwiftDemoUow>();

            kernel.Bind<IBusinessEngineFactory>().To<BusinessEngineFactory>()
               .WithConstructorArgument<IDictionary<Type, object>>(new Dictionary<Type, object>());

            // Tell WebApi how to use our Ninject IoC
            config.DependencyResolver = new NinjectDependencyResolver(kernel);
        }

       
    }
}