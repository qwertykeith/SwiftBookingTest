using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public PhoneNumberController(ISwiftDemoUow uow)
        {
            sdUow = uow;
        }

        #endregion

    }
}
