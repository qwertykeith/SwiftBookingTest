using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcFilterProvider : FilterAttributeFilterProvider
    {
        private readonly Func<IContainer> _container;

        public MvcFilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            var container = _container();

            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}