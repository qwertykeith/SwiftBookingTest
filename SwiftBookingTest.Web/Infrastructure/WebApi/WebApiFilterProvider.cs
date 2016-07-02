using StructureMap;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class WebApiFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly Func<IContainer> _container;

        public WebApiFilterProvider(Func<IContainer> container)
        {
            _container = container;
        }

        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);

            foreach (var filter in filters)
            {
                _container().BuildUp(filter.Instance);
                yield return filter;
            }
        }
    }
}