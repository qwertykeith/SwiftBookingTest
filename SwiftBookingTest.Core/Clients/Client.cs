using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Clients
{
    public class Client : EntityBase
    {
        public Client() : base()
        {

        }

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                AddValidationError(new ValidationError("Name is required"));
            }

            if (string.IsNullOrWhiteSpace(Phone))
            {
                AddValidationError(new ValidationError("Phone is required"));
            }

            if (string.IsNullOrWhiteSpace(Address))
            {
                AddValidationError(new ValidationError("Address is required"));
            }
        }
    }
}
