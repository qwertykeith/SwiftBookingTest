using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Client
{
    public class ClientPhoneViewModel:BaseViewModel
    {
        public string ClientRecordName { get; set; }
        public string PhoneNumberNumber { get; set; }

        public int ClientRecordId { get; set; }

        public int PhoneNumberId { get; set; }

    }
}
