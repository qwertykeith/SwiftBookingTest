using StructureMap;
using System;
using StructureMap.TypeRules;
using System.Web.Http.Filters;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Core;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class WebApiActionFilterRegistry : Registry
    {
        public WebApiActionFilterRegistry(Func<IContainer> containerFactory)
        {
            For<IFilterProvider>().Use<WebApiFilterProvider>();

            Policies.SetAllProperties(x =>
                x.Matching(p =>
                    p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                    p.DeclaringType.Namespace.StartsWith("SwiftBookingTest") &&
                    !p.PropertyType.IsPrimitive &&
                    p.PropertyType != typeof(string)));
        }
    }
}