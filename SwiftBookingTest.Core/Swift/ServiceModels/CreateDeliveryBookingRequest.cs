using System;
using SwiftBookingTest.Core.Common;

namespace SwiftBookingTest.Core.Swift.ServiceModels
{
    public class CreateDeliveryBookingRequest : ServiceRequestBase
    {
        public CreateDeliveryBookingRequest(Guid clientId, SwiftDeliveryDetail pickupDetail, string apiPath = null)
        {
            ClientId = clientId;
            PickupDetail = pickupDetail;
            ApiPath = apiPath;
        }

        public Guid ClientId { get; private set; } 
        public SwiftDeliveryDetail PickupDetail { get; private set; }       
        public string ApiPath { get; private set; }
    }
}
