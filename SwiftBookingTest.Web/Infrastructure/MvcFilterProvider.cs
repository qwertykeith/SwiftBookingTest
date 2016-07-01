using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Infrastructure
{
    public class MvcFilterProvider : IFilterProvider
    {

        private readonly IEnumerable<Filter> _list;

        public MvcFilterProvider(IContainer container)
        {
            _list = GetContainerFilters(container);
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            return _list;
        }

        private static IEnumerable<Filter> GetContainerFilters(IContainer container)
        {
            return
                container.GetAllInstances<IActionFilter>()
                    .Select(instance => new Filter(instance, FilterScope.Action, null));
        }

        /// <summary>
        /// Returns an enumeration of filters.
        /// </summary>
        /// <param name="configuration">The HTTP configuration.</param>
        /// <param name="actionDescriptor">The action descriptor.</param>
        /// <returns>
        /// An enumeration of filters.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            throw new NotImplementedException();
        }
    }
}