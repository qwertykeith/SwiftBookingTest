using System.Web.Http;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Web.Filters;
using System;
using System.Threading.Tasks;
using System.Web.Http.Results;
using System.Collections.Generic;

namespace SwiftBookingTest.Web.Controllers
{
    [NotImplementedExceptionFilter]
    public abstract class ApiControllerBase : ApiController
    {

        protected ISwiftDemoUow sdUow { get; set; }
        protected ISwiftBookingBusinessEngineUow buow { get; set; }

        protected Task<T> WithClient<T>(ISwiftDemoUow sdUow, Func<T> p)
        {
            var rsult = p.Invoke();

            IDisposable disposableClient = sdUow as IDisposable;
            if (disposableClient != null)
                disposableClient.Dispose();

            return Task.FromResult(rsult);
        }


    }
}
