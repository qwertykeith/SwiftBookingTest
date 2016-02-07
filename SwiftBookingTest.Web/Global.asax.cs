using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using Autofac;

using SwiftBookingTest.Core;
using SwiftBookingTest.Core.SwiftApi;

namespace SwiftBookingTest.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            //TODO - move to a module
            builder.Register(c => new SwiftBookingTestContext()).As<IContext>().InstancePerHttpRequest();
            //TODO - add api key and pick address to the web config
            builder.Register(c => new SwiftClient(
                "3285db46-93d9-4c10-a708-c2795ae7872d",
                "57 luscombe st, brunswick, melbourne"
                )).As<ISwiftClient>().SingleInstance();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}