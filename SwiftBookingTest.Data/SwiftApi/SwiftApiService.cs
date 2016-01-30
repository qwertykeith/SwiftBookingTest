using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Data.SwiftApi.Model;

namespace SwiftBookingTest.Data.SwiftApi
{
    public class SwiftApiService
    {
        public const string RootUrl = "https://app.getswift.co/api/v2/";

        private readonly string _apiKey;

        public SwiftApiService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task BookDeliveryAsync(Booking booking)
        {
            var client = new HttpClient();

            await client.PostAsync(RootUrl + "deliveries", null);
        }

    }
}
