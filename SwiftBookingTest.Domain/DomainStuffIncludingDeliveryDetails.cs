using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Domain
{
    /// <summary>
    /// This is meant to illustrate a domain model in which business 
    /// logic could be contained
    /// 
    /// Domain classes would be a cross cutting concern across all layers;
    /// - Presentation
    /// - Service
    /// - Persistence
    /// 
    /// </summary>
    public class DomainStuffIncludingDeliveryDetails
    {
        public DeliveryDetailsDomain FirstOfManyDeliveries { get; set; }

        public List<DeliveryDetailsDomain> HistoryOfManyDeliveries { get; set; }

        public List<DeliveryDetailsDomain> DeliveryBacklog { get; set; }
    }

    /// <summary>
    /// The Delivery Details could be one of many objects in the domain
    /// model. Business logic could be included in the model and it could
    /// then remain independent of both the presentation and persistence layers
    /// 
    /// Massive overkill right...but I am only doing it to illustrate my thinking :)
    /// </summary>
    public class DeliveryDetailsDomain
    {
        public int DeliveryId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
