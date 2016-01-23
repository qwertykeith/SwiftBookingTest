using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients.ServiceModels
{
    public class CreateClientRequest : ServiceRequestBase
    {
        public CreateClientRequest(string name, string phone, string address)
        {
            Name = name;
            Phone = phone;
            Address = address;
        }

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}
