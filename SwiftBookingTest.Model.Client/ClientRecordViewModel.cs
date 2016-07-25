using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model.Client
{
    public class ClientRecordViewModel : BaseViewModel
    {
        [DisplayName("Full Name"),Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        public ICollection<ClientPhoneViewModel> ClientPhones { get; set; }

        public int Rating { get; set; }

        public string FormattedPhoneNumbers
        {
            get
            {
                var numbers= this.ClientPhones != null
                    ? string.Join(", ", this.ClientPhones.Select(x => x.PhoneNumberNumber).ToArray())
                    : string.Empty;
                return numbers;
            }
        }
    }
}
