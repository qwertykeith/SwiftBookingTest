using Ninject;
using StructureMap;
using StructureMap.Attributes;
using SwiftBookingTest.Core;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Filters
{
    public class LoggerFilterAttribute : ActionFilterAttribute
    {
        public Func<ISwiftDemoUow> SDUow { get; set; }
        public Func<ILogger> Logger { get; set; }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var uow = SDUow();
            var logger = Logger();
            base.OnActionExecuting(actionContext);
        }

        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            var uow = SDUow();
            var logger = Logger();
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}