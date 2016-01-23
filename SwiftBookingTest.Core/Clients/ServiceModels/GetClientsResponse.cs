using System.Collections.Generic;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class GetClientsResponse : ServiceResponseBase
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
