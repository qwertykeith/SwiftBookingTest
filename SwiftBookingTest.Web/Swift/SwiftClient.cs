using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

using SwiftBookingTest.Web.Swift.MessageTypes;

namespace SwiftBookingTest.Web.Swift
{
    public class SwiftClient : ISwiftClient
    {
        public async Task<string> SendBookingRequestAsync(MerchantDeliveryBooking merchantDeliveryBooking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(" https://app.getswift.co");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.PostAsJsonAsync("api/v2/deliveries", merchantDeliveryBooking);
                var message = await result.Content.ReadAsStringAsync();
                return message;
            }
        }
    }

    public interface ISwiftClient
    {
        Task<string> SendBookingRequestAsync(MerchantDeliveryBooking merchantDeliveryBooking);
    }
}
