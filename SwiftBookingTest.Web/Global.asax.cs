using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using System.Data.Entity;
using SwiftBookingTest.Core;
using System.Web.Optimization;
//using SwiftBookingTest.Web.Infrastructure;
//using StructureMap;
//using StructureMap.TypeRules;
//using StructureMap.Configuration;
//using StructureMap.Graph;

using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using System.Net.Http;
using StructureMap;
using System.Threading;
using SwiftBookingTest.Web.Infrastructure;
using SwiftBookingTest.Web.Filters;
using SwiftBookingTest.CoreContracts.Tasks;

namespace SwiftBookingTest.Web
{
    public class Global : HttpApplication
    {
        public IContainer Container
        {
            get
            {
                return (IContainer)HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            //Tell WebApi to use our custom Ioc (Ninject)
            //IocConfig.RegisterIoc(GlobalConfiguration.Configuration);

            //Use structure map with Web API
            StructureMapWebApiConfig.RegisterStructureMapForWebApi(GlobalConfiguration.Configuration);

            //Use Structure map with MVC
           
            DependencyResolver.SetResolver(
                    new MVCStructureMapDependencyResolver(() => Container ?? ObjectFactory.Container));

            ObjectFactory.Container.Configure(c =>
            {
                c.AddRegistry(new StandardRegisrty());
                c.AddRegistry(new MvcControllerRegistry());
                c.AddRegistry<MvcRegisrty>();
                c.AddRegistry(new MvcActionFilterRegistry(
                 () => Container ?? ObjectFactory.Container));
                c.AddRegistry(new TaskRegistry());
            });

            // Web API template created these 3
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
#if DEBUG
            Database.SetInitializer(new SwiftDemoInitializer());
#endif
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration, Container ?? ObjectFactory.Container);

            AutoMapperConfig.RegisterMappings();


        }

        public void Application_BeginRequest()
        {
            //Getting nested container is required to properly dispose the in memory object
            Container = ObjectFactory.Container.GetNestedContainer();
           
        }

     

        public void Application_EndRequest()
        {
           
                Container.Dispose();
                Container = null;
        }

    }


}