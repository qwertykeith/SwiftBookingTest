using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace SwiftBookingTest.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                        "~/scripts/jquery.signalR-2.2.0.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootswatch/united/bootstrap.min.css",
                      "~/Content/Site.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/animate.css",
                      "~/Content/toaster.css"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                       "~/scripts/jquery-{version}.js",
                       "~/scripts/bootstrap.js",
                       "~/scripts/angular.js",
                       "~/scripts/angular-ui-router.js",
                       "~/scripts/toaster.js",
                       "~/scripts/extension.array.js"
                       ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/scripts/app/common/commonModule.js",
                        "~/scripts/app/common/APIFactory.js",
                        "~/scripts/app/common/utilities/*.js",
                        "~/scripts/app/MainModule.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/client").Include(
                        "~/scripts/app/client/ClientFactory.js",
                        "~/scripts/app/client/controllers/*.js"
                        ));

            //ClientModule
            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;

        }
    }
}