using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class GetClientsResponse : ServiceResponseBase
    {
        public IEnumerable<Client> Clients { get; set; }
    }
}
