using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SwiftBookingTest.Core.Clients;
using SwiftBookingTest.Core.Swift;
using SwiftBookingTest.Data;

namespace SwiftBookingTest.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            GlobalConfiguration.Configure(WebApiConfig.Register);            
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitContainer();            
        }

        private void InitContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<ClientService>()
                .As<IClientService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<SwiftService>()
                .As<ISwiftService>()
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterType<SwiftStorage>()
                .As<IClientStorage>()
                .AsImplementedInterfaces()
                .InstancePerDependency();
            
            var swiftSettings = new SwiftApiSettings();
            swiftSettings.BaseAddress = ConfigurationManager.AppSettings["SwiftApiBaseAddress"];
            swiftSettings.MerchantKey = ConfigurationManager.AppSettings["SwiftApiMerchantKey"];
            swiftSettings.ApiRoot = ConfigurationManager.AppSettings["SwiftApiRoot"];

            builder.RegisterInstance(swiftSettings).As<SwiftApiSettings>();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }        
    }
}