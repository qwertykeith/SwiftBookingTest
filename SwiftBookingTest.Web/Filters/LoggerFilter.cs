using Ninject;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Filters
{
    public class LoggerFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly ILogger Logger;
        public LoggerFilter()
        { }
        public LoggerFilter(ILogger logger)
        {
            this.Logger = logger;
        }
      

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var kk = Logger;
            return Task.FromResult<object>(null);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var kk = Logger;
            return Task.FromResult<object>(null);
        }

    }
}