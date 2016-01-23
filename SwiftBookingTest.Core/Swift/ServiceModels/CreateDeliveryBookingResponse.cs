using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Swift.ServiceModels
{
    public class CreateDeliveryBookingResponse : ServiceResponseBase
    {
        public dynamic Content { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
