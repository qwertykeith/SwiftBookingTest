using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Checkk;
using Checkk.Exceptions;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers.Features
{
    public class AddClientRecordController : ApiController
    {
        private readonly IBookingContext _context;

        public AddClientRecordController(IBookingContext context)
        {
            _context = context;
        }

        public HttpResponseMessage Post([FromBody] AddClientRecordDto dto)
        {
            try
            {
                dto.Validate();
            }
            catch (InvariantException ex)
            {
                return new HttpResponseMessage(HttpStatusCode.NotAcceptable)
                {
                    Content = new StringContent(ex.Message)
                };
            }

            var record = new ClientRecord(dto.Name, dto.Address, dto.Phone);

            _context.ClientRecords.Add(record);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, record.Id);
        }
    }
}