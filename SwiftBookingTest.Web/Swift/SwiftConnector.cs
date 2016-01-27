using SwiftBookingTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Web.Swift.MessageTypes;

namespace SwiftBookingTest.Web.Swift
{
    public interface ISwiftConnector
    {
        Task<string> BookDeliveryAsync(DeliveryPoint sender, DeliveryPoint recipient);
    }

    public class SwiftConnector : ISwiftConnector
    {
        private Guid apiKey;
        private ISwiftClient swiftClient;

        public SwiftConnector(Guid apiKey, ISwiftClient swiftClient)
        {
            this.apiKey = apiKey;
            this.swiftClient = swiftClient;
        }

        public async Task<string> BookDeliveryAsync(DeliveryPoint sender, DeliveryPoint recipient)
        {
            var booking = BookingTranslator.BuildBooking(sender, recipient);
            var merchantDeliveryBooking = new MerchantDeliveryBooking()
            {
                apiKey = this.apiKey,
                booking = booking,
            };
            return await swiftClient.SendBookingRequestAsync(merchantDeliveryBooking);
        }
    }
}
