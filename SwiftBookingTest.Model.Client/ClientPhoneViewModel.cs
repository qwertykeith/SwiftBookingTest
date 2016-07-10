using SwiftBookingTest.Model.Client.CustomAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Client
{
    public class ClientPhoneViewModel:BaseViewModel
    {
        [DataType(DataType.Text)]
        public string ClientRecordName { get; set; }
        [DataType(DataType.Text)]
        public string PhoneNumberNumber { get; set; }

        [HiddenInput]
        public int ClientRecordId { get; set; }
        [HiddenInput]
        public int PhoneNumberId { get; set; }

    }
}
