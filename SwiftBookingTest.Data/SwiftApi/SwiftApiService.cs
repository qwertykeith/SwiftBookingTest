using System.Net.Http;
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

        public async Task<string> BookDeliveryAsync(BookingDetail dropoffDetail, BookingDetail pickupDetail)
        {
            var client = new HttpClient();

            var response = await client.PostAsJsonAsync(RootUrl + "deliveries", new
            {
                apiKey = _apiKey,
                booking = new
                {
                    pickupDetail,
                    dropoffDetail
                }
            });

            return await response.Content.ReadAsStringAsync();
        }
    }
}
