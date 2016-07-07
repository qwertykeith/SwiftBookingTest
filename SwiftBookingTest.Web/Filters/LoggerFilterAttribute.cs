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
using System.Security.Principal;
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
        public Func<IIdentity> CurrentUser { get; set; }

       

        private string _description = "";
        private Dictionary<string, object> _parameters;

        public LoggerFilterAttribute(string description)
        {
            _description = description;
        }

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
            _parameters = actionContext.ActionArguments;
            _parameters.ToList().ForEach((x) =>
            {
                _description = _description.Replace("{" + x.Key + "}", x.Value.ToString());
            });
            logger.CreateAudit(_description + " and loged in user is " + CurrentUser().Name);
            return base.OnActionExecutingAsync(actionContext, cancellationToken);
        }
    }
}