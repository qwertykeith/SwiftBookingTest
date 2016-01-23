using System.Net;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Swift.ServiceModels
{
    public class CreateDeliveryBookingResponse : ServiceResponseBase
    {
        public dynamic Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
