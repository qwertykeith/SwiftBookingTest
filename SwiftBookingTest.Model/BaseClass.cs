using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SwiftBookingTest.Model
{
    /// <summary>
    /// Represents base class property
    /// </summary>
    [DataContract]
    public abstract class BaseClass : IObjectWithState
    {
        private int _id;
        private byte[] _rowVersion { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [DataMember, Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        [DataMember, Timestamp]
        public byte[] RowVersion
        {
            get { return _rowVersion; }
            set { _rowVersion = value; }
        }

        [NotMapped]
        public State State
        {
            get;
            set;

        }
    }
}