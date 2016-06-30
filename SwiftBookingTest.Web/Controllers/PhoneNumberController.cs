using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;

namespace SwiftBookingTest.Web.Controllers
{
    public class PhoneNumberController : ApiControllerBase
    {
        #region Contructor


        /// <summary>
        /// Initializes a new instance of the <see cref="ClientsController"/> class.
        /// </summary>
        /// <param name="uow">The uow.</param>
        public PhoneNumberController(ISwiftDemoUow uow, IIdentity identity)
        {
            sdUow = uow;
            var gg = identity;
        }
        #endregion

        public async Task<IHttpActionResult> Get()
        {
            var model = await Task.Factory.StartNew(() => sdUow.PhoneNumbers.GetAll().ToList());
            return Ok(model);
        }


    }
}
