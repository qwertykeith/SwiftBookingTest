using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;

[assembly: OwinStartup(typeof(SwiftBookingTest.Web.Startup))]
namespace SwiftBookingTest.Web
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.MapSignalR();
        }

        public static void ConfigureSignalR(IAppBuilder app, HubConfiguration config)
        {
            app.MapSignalR(config);
        }

        
    }
}