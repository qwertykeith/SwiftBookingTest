using System.Web.Http;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.CoreContracts.BusinessEngine;
using SwiftBookingTest.Web.Filters;

namespace SwiftBookingTest.Web.Controllers
{
    [NotImplementedExceptionFilter]
    public abstract class ApiControllerBase : ApiController
    {

        protected ISwiftDemoUow sdUow { get; set; }
        protected ISwiftBookingBusinessEngineUow buow { get; set; }
    }

}
