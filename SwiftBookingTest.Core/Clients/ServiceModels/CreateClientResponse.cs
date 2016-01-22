using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class CreateClientResponse : ServiceResponseBase
    {
        public Client Client { get; set; }
    }
}
