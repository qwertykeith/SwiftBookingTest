using SwiftBookingTest.Core;

namespace SwiftBookingTest.Web.Models
{
    public class PersonsViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Person[] SavedPeople { get; set; }
    }
}