using FluentValidation;
using SwiftBookingTest.Model.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Model
{
    /// <summary>
    /// Represents the client phone number
    /// </summary>
    [DataContract]
    public class ClientPhone : BaseClass
    {

        private ClientRecord _clientRecord;
        private int _clientRecordId;
        private PhoneNumber _phoneNumber;
        private int _phoneNumberId;

        /// <summary>
        /// Gets or sets the phone number identifier.
        /// </summary>
        /// <value>
        /// The phone number identifier.
        /// </value>
        [DataMember, Required(ErrorMessage = "Phone number is mandatory")]
        public int PhoneNumberId
        {
            get { return _phoneNumberId; }
            set { _phoneNumberId = value; }
        }


        /// <summary>
        /// Gets or sets the client record.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The client record.
        /// </value>
        [DataMember]
        public virtual ClientRecord ClientRecord
        {
            get { return _clientRecord; }
            set { _clientRecord = value; }
        }

        /// <summary>
        /// Gets or sets the client record identifier.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The client record identifier.
        /// </value>
        [DataMember, Required(ErrorMessage = "Client record is mandatory")]
        public int ClientRecordId
        {
            get { return _clientRecordId; }
            set { _clientRecordId = value; }
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        /// <value>
        /// The number.
        /// </value>
        [DataMember]
        public virtual PhoneNumber PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }


        protected override IValidator GetValidator()
        {
            return new ClientPhoneValidator();
        }

    }
}
