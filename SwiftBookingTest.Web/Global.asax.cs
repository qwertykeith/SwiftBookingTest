﻿using System;
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
using StructureMap;
using SwiftBookingTest.Web.Infrastructure;
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

            //AutoMapperConfig.RegisterMappings();
            using (var container = ObjectFactory.Container.GetNestedContainer())
            {
                foreach (var task in container.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }

                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
        }

        public void Application_BeginRequest()
        {
            //Getting nested container is required to properly dispose the in memory object
            Container = ObjectFactory.Container.GetNestedContainer();

            foreach (var task in Container.GetAllInstances<IRunOnEachRequest>())
            {
                task.Execute();
            }
        }

        public void Application_EndRequest()
        {

            try
            {
                foreach (var task in
                    Container.GetAllInstances<IRunAfterEachRequest>())
                {
                    task.Execute();
                }
            }
            finally
            {
                Container.Dispose();
                Container = null;
            }
        }

        public void Application_Error()
        {
            foreach (var task in Container.GetAllInstances<IRunOnError>())
            {
                task.Execute();
            }
        }

    }


}