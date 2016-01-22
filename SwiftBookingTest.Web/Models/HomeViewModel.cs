using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftBookingTest.Core.Clients;

namespace SwiftBookingTest.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<ClientViewModel> Clients { get; set; }
    }
}
