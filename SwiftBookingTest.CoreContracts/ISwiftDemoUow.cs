using SwiftBookingTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.CoreContracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISwiftDemoUow
    {
        /// <summary>
        /// Save pending changes to the data store.
        /// </summary>
        void Commit();

        /// <summary>
        /// Gets the client records.
        /// </summary>
        /// <value>
        /// The client records.
        /// </value>
        IRepository<ClientRecord> ClientRecords { get; }
        /// <summary>
        /// Gets the client phones.
        /// </summary>
        /// <value>
        /// The client phones.
        /// </value>
        IRepository<ClientPhone> ClientPhones { get; }
        /// <summary>
        /// Gets the phone numbers.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        IRepository<PhoneNumber> PhoneNumbers { get; }
    }
}
