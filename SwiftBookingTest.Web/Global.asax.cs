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

namespace SwiftBookingTest.Web
{
    public class Global : HttpApplication
    {
        //private Container container { get; set; }
        //public IContainer Container
        //{
        //    get
        //    {
        //        return (IContainer)HttpContext.Current.Items["_Container"];
        //    }
        //    set
        //    {
        //        HttpContext.Current.Items["_Container"] = value;
        //    }
        //}

        /// <summary>
        /// Handles the Start event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            // Tell WebApi to use our custom Ioc (Ninject)
            //IocConfig.RegisterIoc(GlobalConfiguration.Configuration);

            StructureMapConfig.RegisterStructureMapForWebApi(GlobalConfiguration.Configuration);

            //HttpConfiguration config = GlobalConfiguration.Configuration;
            //config.Services
            //.Replace(typeof(IHttpControllerActivator), new ServiceActivator(config));
            //DependencyResolver.SetResolver(new StructureMapDependencyResolver(() => Container ?? ObjectFactory.Container));
            //ObjectFactory.Container.Configure(cfg =>
            //{
            //    cfg.AddRegistry(new StandardRegistry());
            //    cfg.AddRegistry(new ControllerRegisrty());
            //    cfg.AddRegistry(new MvcRegistry());
            //});

            // Web API template created these 3
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
#if DEBUG
            Database.SetInitializer(new SwiftDemoInitializer());
#endif
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfig.CustomizeConfig(GlobalConfiguration.Configuration);

            
        }

        //void Application_BeginRequest()
        //{
        //    Container = ObjectFactory.Container.GetNestedContainer();
        //}

        //void Application_EndRequest()
        //{
        //    Container.Dispose();
        //    Container = null;
        //}

     
    }


}