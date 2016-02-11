using SwiftBookingTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Service
{
    public interface IDeliveryService : IDisposable
    {
        void SaveDeliveryDetails(DeliveryDetailsDomain details);
        List<DeliveryDetailsDomain> GetStuffThatHasBeenDelivered();
    }
}
