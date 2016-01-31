using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.SwiftAPI
{
    public class DeliveryService
    {
        private string server;
        private string merchantKey;

        public DeliveryService(string merchantKey, string server = "https://app.getswift.co")
        {
            this.merchantKey = merchantKey;
            this.server = server;
        }

        public async Task<string> BookSync(Person pickup, Person dropoff)
        {
            using (var client = new HttpClient())
            {
                // New code:
                client.BaseAddress = new Uri(server);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var body = new
                {
                    apiKey = merchantKey,
                    booking = new
                    {
                        pickupDetail = pickup,
                        dropoffDetail = dropoff
                    }
                };

                HttpResponseMessage response = await client.PostAsJsonAsync("api/v2/deliveries", body);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
