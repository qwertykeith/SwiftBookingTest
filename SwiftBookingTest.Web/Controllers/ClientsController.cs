using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Model;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;
using Newtonsoft.Json.Linq;
using SwiftBookingTest.Web.Helpers;
using SwiftBookingTest.Web.Filters;
using System.Security.Principal;
using AutoMapper.QueryableExtensions;
using SwiftBookingTest.Model.Client;

namespace SwiftBookingTest.Web.Controllers
{

    public class ClientsController : ApiControllerBase
    {
        protected IIdentity Identity { get; private set; }

        #region Contructor
        public ClientsController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public ClientsController(ISwiftDemoUow uow, IIdentity identity)
        {
            sdUow = uow;
            Identity = identity;
        }

        #endregion

        /// <summary>
        /// Gets this clients records.
        /// </summary>
        /// <returns></returns>
        [LoggerFilter("Getting data for clients")]
        public async Task<IHttpActionResult> Get()
        {
            return await WithClient<IHttpActionResult>(sdUow, () =>
            {
                var records = sdUow.ClientRecords.GetAll().ProjectTo<ClientRecordViewModel>().ToList();
                var list =
                 sdUow.ClientRecords.GetAll()
                 .Include(x => x.ClientPhones.Select(y => y.PhoneNumber))
                 .OrderBy(x => x.Name).ToList();
                // Set client record to null to fix circular reference issue
                foreach (var cp in list.SelectMany(x => x.ClientPhones))
                {
                    cp.ClientRecord = null;
                }
                return Ok<IEnumerable<ClientRecord>>(list);
            });
        }

        /// <summary>
        /// Add the specified attendance.
        /// </summary>
        /// <param name="attendance">The attendance.</param>
        /// <returns></returns>
        [Route("Post")]
        [LoggerFilter("Creating new client record")]
        public async Task<IHttpActionResult> Post(ClientRecord clientRecord)
        {
            sdUow.ClientRecords.Add(clientRecord);
            sdUow.Commit();
            // Set client record to null to fix circular reference issue
            clientRecord.ClientPhones.ToList().ForEach(x => x.ClientRecord = null);
            var response = Request.CreateResponse(HttpStatusCode.Created, clientRecord);
            return Ok(await Task.FromResult<HttpResponseMessage>(response));
        }

        /// <summary>
        /// Puts the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="clientRecord">The client record.</param>
        /// <returns></returns>
        [LoggerFilter("Updating data for client where id is {Id}")]
        public async Task<IHttpActionResult> Put(int Id, ClientRecord clientRecord)
        {
            clientRecord.Name = Identity.Name;
            var newPhones = clientRecord.ClientPhones.ToList();
            newPhones.Where(x => x.Id == default(int) || x.Id < 0).ToList().ForEach((x) =>
            {
                x.State = State.Added;
                x.ClientRecordId = clientRecord.Id;
                x.PhoneNumberId = x.PhoneNumber.Id;
                string number = x.PhoneNumber.Number;
                x.PhoneNumber = new PhoneNumber { Number = number };
                sdUow.ClientPhones.Add(x);
            });
            sdUow.ClientRecords.Update(clientRecord);
            sdUow.Commit();
            //throw new InvalidOperationException();
            return Ok(await Task.FromResult(new HttpResponseMessage(HttpStatusCode.NoContent)));
        }

    }

}
