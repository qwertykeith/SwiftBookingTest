using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
