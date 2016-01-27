using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Web.Models
{
    public class IndexViewModel
    {
        public IEnumerable<DeliveryPoint> DeliveryPoints { get; set; }
        public string Message { get; set; }

        public DeliveryPoint DeliveryPointToAdd { get; set; }
    }
}
