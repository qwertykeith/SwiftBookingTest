using System.Web.Http;
using SwiftBookingTest.CoreContracts;

namespace SwiftBookingTest.Web.Controllers
{
    public abstract class ApiControllerBase : ApiController
    {
        protected ISwiftDemoUow sdUow { get; set; }
    }

}
