using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;

namespace SwiftBookingTest.Core.SwiftApi
{
    public class SwiftClient: ISwiftClient
    {
        private readonly string _apiKey;
        private readonly string _pickupAddress;

        public SwiftClient(string apiKey, string pickupAddress)
        {
            _apiKey = apiKey;
            _pickupAddress = pickupAddress;
        }

        public string CreateDelivery(string dropOffAddress)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var deliveryRequest = Build(dropOffAddress);

            var content = ToJsonString(deliveryRequest);

            var result = client.PostAsync(new Uri("https://app.getswift.co/api/v2/deliveries"), content).Result;

            return result.Content.ReadAsStringAsync().Result;
        }

        DeliveryRequest Build(string dropOffAddress)
        {
            return new DeliveryRequest
            {
                apiKey = _apiKey,
                booking = new Booking
                {
                    pickupDetail = new BookingAddress
                    {
                        address = _pickupAddress
                    },
                    dropoffDetail = new BookingAddress
                    {
                        address = dropOffAddress
                    },
                }
            };
        }

        StringContent ToJsonString(DeliveryRequest request)
        {
            var jsonSer = new DataContractJsonSerializer(typeof(DeliveryRequest));
            // use the serializer to write the object to a MemoryStream 
            var ms = new MemoryStream();
            jsonSer.WriteObject(ms, request);
            ms.Position = 0;

            //use a Stream reader to construct the StringContent (Json) 
            var sr = new StreamReader(ms);
            return new StringContent(sr.ReadToEnd(), System.Text.Encoding.UTF8, "application/json");
        }
    }
}
