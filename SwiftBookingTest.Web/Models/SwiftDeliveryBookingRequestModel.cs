using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Web.Models
{
    public class SwiftDeliveryBookingRequestModel
    {
        public string ApiKey { get; set; }
        public SwiftBooking Booking { get; set; }
    }

    public class SwiftBooking
    {
        public SwiftDetail PickupDetail { get; set; }
        public SwiftDetail DropoffDetail { get; set; }
    }

    public class SwiftDetail
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
