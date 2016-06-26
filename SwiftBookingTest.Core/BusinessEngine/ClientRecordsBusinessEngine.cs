using SwiftBookingTest.CoreContracts.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.BusinessEngine
{
    public class ClientRecordsBusinessEngine : IClientRecordsBusinessEngine
    {
        /// <summary>
        /// Determines whether [is client has phone] [the specified client identifier].
        /// </summary>
        /// <param name="clientId">The client identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsClientHasPhone(long? clientId)
        {
            throw new NotImplementedException();
        }
    }
}
