using System.Linq;
using System.Web.Http;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers.Features
{
    public class GetClientRecordsController : ApiController
    {
        private readonly IBookingContext _context;

        public GetClientRecordsController(IBookingContext context)
        {
            _context = context;
        }

        public ClientRecord[] Get()
        {
            return _context.ClientRecords.ToArray();
        }
    }
}