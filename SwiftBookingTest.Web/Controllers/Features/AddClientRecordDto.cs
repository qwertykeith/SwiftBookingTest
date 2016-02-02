using System;
using Checkk;

namespace SwiftBookingTest.Web.Controllers.Features
{
    public class AddClientRecordDto
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public void Validate()
        {
            Check.That(() => Id).IsEqualTo(null, "Cannot add an already added record");
            Check.That(() => Name).IsNotNullOrEmpty("Name is required");
            Check.That(() => Address).IsNotNullOrEmpty("Address is required");
            Check.That(() => Phone).IsNotNullOrEmpty("Phone is null or required");
        }
    }
}