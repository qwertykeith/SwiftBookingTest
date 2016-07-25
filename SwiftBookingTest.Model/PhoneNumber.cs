using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SwiftBookingTest.Model
{
    /// <summary>
    /// Phone number class
    /// </summary>
    /// <seealso cref="SwiftBookingTest.Model.BaseClass" />
    [DataContract]
    public class PhoneNumber : BaseClass
    {
        private string _number;

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        /// <value>
        /// The numbers.
        /// </value>
        [DataMember, Required(ErrorMessage = "Number is mandatory"),
            StringLength(50, ErrorMessage = "Number is not valid")]
        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

    }
}
