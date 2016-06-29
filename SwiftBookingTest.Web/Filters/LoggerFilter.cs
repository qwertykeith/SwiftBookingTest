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
    public class LoggerFilter : ActionFilterAttribute
    {
        [Inject]
        protected ILogger logger { get; private set; }

        public LoggerFilter()
        {

        }
      

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            logger?.CreateAudit();
            return Task.FromResult<object>(null);
        }

        public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            logger?.CreateAudit();
            return Task.FromResult<object>(null);
        }

    }
}