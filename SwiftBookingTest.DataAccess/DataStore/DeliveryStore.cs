using SwiftBookingTest.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.DataAccess.DataStore
{
    public class DeliveryStore
    {
        private DeliveryContext context = null;

        public DeliveryStore(DeliveryContext context)
        {
            this.context = context;
        }

        public void SaveDeliveryDetails(DeliveryDetails details)
        {
            context.Deliveries.Add(details);
            context.SaveChanges();

        }
    }
}
