using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Client
{
    public class ClientRecordViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<ClientPhoneViewModel> ClientPhones { get; set; }
    }
}
