using System.Threading.Tasks;
using SwiftBookingTest.Core.Swift.ServiceModels;

namespace SwiftBookingTest.Core.Swift
{
    public interface ISwiftService
    {
        Task<CreateDeliveryBookingResponse> CreateDeliveryBooking(CreateDeliveryBookingRequest request);
    }
}
