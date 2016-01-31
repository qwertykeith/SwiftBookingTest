using Newtonsoft.Json;

namespace SwiftBookingTest.Data.SwiftApi.Model
{
    public class BookingDetail
    {
        [JsonProperty("name)")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
