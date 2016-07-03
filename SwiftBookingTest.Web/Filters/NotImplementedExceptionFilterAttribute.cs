using SwiftBookingTest.CoreContracts.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Filters
{
    public class NotImplementedExceptionFilterAttribute: ExceptionFilterAttribute
    {
        

        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            actionExecutedContext.Request
                .CreateErrorResponse(HttpStatusCode.InternalServerError,
                actionExecutedContext.Exception.Message);
           
        }
    }
}