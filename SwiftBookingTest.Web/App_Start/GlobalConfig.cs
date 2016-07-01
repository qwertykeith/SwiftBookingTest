using System.Web.Http;
using Newtonsoft.Json.Serialization;
using SwiftBookingTest.Web.Filters;

namespace SwiftBookingTest.Web
{
    public static class GlobalConfig
    {
        public static void CustomizeConfig(HttpConfiguration config)
        {
            // Remove Xml formatters. This means when we visit an endpoint from a browser,
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Here we configure it to write JSON property names with camel casing
            // without changing our server-side data model:
            //var json = config.Formatters.JsonFormatter;
            //json.SerializerSettings.ContractResolver =
            //    new CamelCasePropertyNamesContractResolver();

            ////Helpful to remove circular reference
            config.Formatters.JsonFormatter
            .SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            config.Filters.Add(new ValidationActionFilter());
            config.Filters.Add(new LoggerFilter());
        }
    }
}