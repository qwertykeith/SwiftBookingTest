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
    /// Represents the client record
    /// </summary>
    [DataContract]
    public class ClientRecord : BaseClass
    {
        private string _name;
        private string _address;
        private ICollection<ClientPhone> _clientPhones;



        public ClientRecord()
        {
            this.ClientPhones = new List<ClientPhone>();
        }
        /// <summary>
        /// Gets or sets the name of the client.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [DataMember,
            Required(ErrorMessage = "Name is mandatory"),
            StringLength(50, ErrorMessage = "Name is not valid")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Gets or sets the address of the client.
        /// TODO: Get error messaget from resource file
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        [DataMember,
            Required(ErrorMessage = "Address is mandatory"),
            StringLength(50, ErrorMessage = "Address is not valid")]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the phone numbers of the client.
        /// </summary>
        /// <value>
        /// The phone numbers.
        /// </value>
        [DataMember]
        public ICollection<ClientPhone> ClientPhones
        {
            get { return _clientPhones; }
            set { _clientPhones = value; }
        }

        [DataMember]
        public string FormattedPhoneNumbers
        {
            get
            {
                return this.ClientPhones != null
                    ? string.Join(", ", this.ClientPhones.Select(x => x.PhoneNumber.Number).ToArray())
                    : string.Empty;
            }
        }
    }
}
