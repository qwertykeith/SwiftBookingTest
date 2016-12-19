using StructureMap;
using StructureMap.TypeRules;
using SwiftBookingTest.Core.Repository;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class ApiActionFilterRegistry : Registry
    {
        public Func<IContainer> _container { get; set; }
        public ApiActionFilterRegistry(Func<IContainer> container)
        {
            _container = container;

            For<IFilterProvider>().Use(
                new StructureMapApiFilterProvider(container));

            Policies.SetAllProperties(x =>
                x.Matching(p =>
                    p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                    p.DeclaringType.Namespace.StartsWith("SwiftBookingTest") &&
                    !p.PropertyType.IsPrimitive &&
                    p.PropertyType != typeof(string)));
        }
    }
}