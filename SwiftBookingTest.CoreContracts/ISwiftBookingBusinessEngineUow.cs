using SwiftBookingTest.CoreContracts.BusinessEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts
{
    public interface ISwiftBookingBusinessEngineUow
    {
        /// <summary>
        /// Gets or sets the client records business engine.
        /// </summary>
        /// <value>
        /// The client records business engine.
        /// </value>
        IClientRecordsBusinessEngine ClientRecordBusinessValidatiors { get; }

        /// <summary>
        /// Gets the phone number business validatiors.
        /// </summary>
        /// <value>
        /// The phone number business validatiors.
        /// </value>
        IPhoneNumberBusinessEngine PhoneNumberBusinessValidatiors { get; }
    }
}
