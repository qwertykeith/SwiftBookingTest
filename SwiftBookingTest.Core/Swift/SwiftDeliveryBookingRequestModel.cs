namespace SwiftBookingTest.Core.Swift
{
    public class SwiftDeliveryBookingRequestModel
    {
        public string ApiKey { get; set; }
        public SwiftBooking Booking { get; set; }
    }

    public class SwiftBooking
    {
        public SwiftDeliveryDetail PickupDetail { get; set; }
        public SwiftDeliveryDetail DropoffDetail { get; set; }
    }

    public class SwiftDeliveryDetail
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
