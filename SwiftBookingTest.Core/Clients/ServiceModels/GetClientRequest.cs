using System;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class GetClientRequest : ServiceRequestBase
    {
        public GetClientRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }        
    }
}
