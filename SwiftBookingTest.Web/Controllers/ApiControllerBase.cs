using System.Web.Http;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.CoreContracts.BusinessEngine;

namespace SwiftBookingTest.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ISwiftDemoUow sdUow { get; set; }
        protected IClientRecordsBusinessEngine buow { get; set; }
    }

}
