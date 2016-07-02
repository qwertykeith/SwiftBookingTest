using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using StructureMap.Attributes;


namespace SwiftBookingTest.Web.Infrastructure
{
    public class StructureMapApiFilterProvider : ActionDescriptorFilterProvider
    {
        private Func<IContainer> _container;

        public StructureMapApiFilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            
            var filters = base.GetFilters(configuration, actionDescriptor);
            var container = _container();
            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}