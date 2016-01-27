using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Swift.MessageTypes;

namespace SwiftBookingTest.Web.Swift
{
    public static class BookingTranslator
    {
        public static Booking BuildBooking(DeliveryPoint sender, DeliveryPoint recipient)
        {
            return new Booking()
            {
                pickupDetail = TranslateToAddressDetail(sender),
                dropoffDetail = TranslateToAddressDetail(recipient),
            };
        }
        private static AddressDetail TranslateToAddressDetail(DeliveryPoint deliveryPoint)
        {
            return new AddressDetail() { address = deliveryPoint.Address, name = deliveryPoint.Name, phone = deliveryPoint.Phone };
        }
    }
}
