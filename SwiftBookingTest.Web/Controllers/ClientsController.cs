using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using SwiftBookingTest.Web.Helpers;
using SwiftBookingTest.Core.Extensions;
using SwiftBookingTest.CoreContracts.BusinessEngine;

namespace SwiftBookingTest.Web.Controllers
{
    public class ClientsController : ApiControllerBase
    {
        #region Contructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public ClientsController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        #endregion

        /// <summary>
        /// Gets this clients records.
        /// </summary>
        /// <returns></returns>
        public async Task<IHttpActionResult> Get()
        {
            var picks = sdUow.OfficeAssignments.GetByInstructor(1).ToList();
            var list = await Task.Factory.StartNew(() =>
             sdUow.ClientRecords.GetAll()
             .Include(x => x.ClientPhones.Select(y => y.PhoneNumber))
             .OrderBy(x => x.Name).ToList());

            // Set client record to null to fix circular reference issue
            foreach (var cp in list.SelectMany(x => x.ClientPhones))
            {
                cp.ClientRecord = null;
                //var thooo = buow.PhoneNumberBusinessValidatiors.IsNull(cp.PhoneNumber);
            }
            return Ok<IEnumerable<ClientRecord>>(list);
        }

        /// <summary>
        /// Add the specified attendance.
        /// </summary>
        /// <param name="attendance">The attendance.</param>
        /// <returns></returns>
        [Route("Post")]
        public HttpResponseMessage Post(ClientRecord clientRecord)
        {


            sdUow.ClientRecords.Add(clientRecord);
            sdUow.Commit();
            // Set client record to null to fix circular reference issue
            clientRecord.ClientPhones.ToList().ForEach(x => x.ClientRecord = null);
            var response = Request.CreateResponse(HttpStatusCode.Created, clientRecord);
            return response;
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Put(int Id, ClientRecord clientRecord)
        {
            //var isNull = buow.ClientRecordBusinessValidatiors.IsNull(clientRecord, true);

            clientRecord.Name = "Biknanu";
            var newPhones = clientRecord.ClientPhones.ToList();
            newPhones.Where(x => x.Id == default(int) || x.Id < 0).ToList().ForEach((x) =>
            {
                x.ClientRecordId = clientRecord.Id;
                x.PhoneNumberId = x.PhoneNumber.Id;
                string number = x.PhoneNumber.Number;
                x.PhoneNumber = new PhoneNumber { Number = number };
                sdUow.ClientPhones.Add(x);
            });
            sdUow.ClientRecords.Update(clientRecord);
            sdUow.Commit();
            return await Task.FromResult(new HttpResponseMessage(HttpStatusCode.NoContent));
        }

        /// <summary>
        /// Sends the delivery.
        /// </summary>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        [HttpPost, Route("SendDelivery")]
        public async Task<IHttpActionResult> SendDelivery(ClientRecord clientRecord)
        {
            using (HttpClient client = new HttpClient())
            {
                var result = await client.PostStringAsync<object>(CommonHelper.GetSwiftApi("deliveries"), SetPayload(clientRecord));
                return Ok(JObject.Parse(await result.Content.ReadAsStringAsync()));
            }
        }

        /// <summary>
        /// Sets the payload.
        /// </summary>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        private object SetPayload(ClientRecord clientRecord)
        {
            var payLoad = new
            {
                apiKey = "3285db46-93d9-4c10-a708-c2795ae7872d",
                booking = new
                {
                    pickupDetail = new
                    {
                        address = "57 luscombe st, brunswick, melbourne"
                    },
                    dropoffDetail = new
                    {
                        address = clientRecord.Address
                    }
                }
            };
            return payLoad;
        }


    }
}
