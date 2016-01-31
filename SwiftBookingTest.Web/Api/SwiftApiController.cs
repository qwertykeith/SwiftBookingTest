using System.Threading.Tasks;
using System.Web.Http;
using SwiftBookingTest.Data;
using SwiftBookingTest.Data.SwiftApi;
using SwiftBookingTest.Data.SwiftApi.Model;

namespace SwiftBookingTest.Web.Api
{
    [RoutePrefix("api/swift")]
    public class SwiftApiController : ApiController
    {
        private readonly SwiftBookingContext _context = new SwiftBookingContext();
        private readonly SwiftApiService _apiService = new SwiftApiService("3285db46-93d9-4c10-a708-c2795ae7872d");

        [Route("deliveries/{clientId}")]
        [HttpPost]
        public async Task<IHttpActionResult> BookDelivery(int clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);

            if (client == null)
                return BadRequest("Client not found");

            //we need to now register this with the Swift API
            var result = await _apiService.BookDeliveryAsync(new BookingDetail
            {
                Name = client.Name,
                Phone = client.Phone,
                Address = client.Address
            }, new BookingDetail
            {
                Name = "John Smith",
                Phone = "0412 345 678",
                Address = "1 Bourke St, Melbourne, Victoria 3000"
            });

            return Ok(result);
        }
    }
}
