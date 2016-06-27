using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.CoreContracts.BusinessEngine;


namespace SwiftBookingTest.CoreContracts
{
    public interface ISwiftBookingBusinessEngineUow
    {
        /// <summary>
        /// Gets or sets the swift demo uow.
        /// </summary>
        /// <value>
        /// The swift demo uow.
        /// </value>
        ISwiftDemoUow SwiftDemoUow { get; set; }
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
