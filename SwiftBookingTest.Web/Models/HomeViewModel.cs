using System.Collections.Generic;

namespace SwiftBookingTest.Web.Models
{
    public class HomeViewModel
    {
        public ClientViewModel NewClient { get; set; }
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}
