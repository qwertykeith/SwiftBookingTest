using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace SwiftBookingTest.Web.Controllers.Features
{
    public interface ISwiftApi
    {
        [Post("/api/v2/deliveries")]
        Task<HttpResponseMessage> BookDelivery([Body] BookDeliveryRequestDto request);
    }
}