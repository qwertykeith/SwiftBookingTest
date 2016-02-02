using System.Data;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SwiftBookingTest.Web.Configuration;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers.Features
{
    public class BookClientRecordController : ApiController
    {
        private readonly ISwiftApi _swiftApi;
        private readonly MerchantKeySetting _merchantKey;
        private readonly IBookingContext _context;

        public BookClientRecordController(ISwiftApi swiftApi, MerchantKeySetting merchantKey, IBookingContext context)
        {
            _swiftApi = swiftApi;
            _merchantKey = merchantKey;
            _context = context;
        }

        public async Task<HttpResponseMessage> Post([FromBody] BookClientRecordRequestDto dto)
        {
            using (var transaction = _context.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                var record = _context.ClientRecords.Find(dto.Id);

                if (record == null)
                {
                    transaction.Rollback();

                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Record not found");
                }

                if (record.IsBooked)
                {
                    transaction.Rollback();

                    return Request.CreateResponse(HttpStatusCode.NotAcceptable, "Record is already booked");
                }

                var response = await _swiftApi.BookDelivery(new BookDeliveryRequestDto(
                    _merchantKey,
                    record.Name,
                    record.Phone,
                    record.Address));

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    record.Book();
                    _context.SaveChanges();
                    transaction.Commit();
                }
                else
                {
                    transaction.Rollback();
                }

                return response;
            }
        }
    }
}