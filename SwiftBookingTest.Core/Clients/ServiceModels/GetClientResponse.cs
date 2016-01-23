using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class GetClientResponse : ServiceResponseBase
    {
        public Client Client { get; set; }
    }
}
