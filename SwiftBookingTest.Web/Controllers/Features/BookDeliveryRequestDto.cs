namespace SwiftBookingTest.Web.Controllers.Features
{
    public class BookDeliveryRequestDto
    {
        public string ApiKey { get; private set; }
        public BookingDto Booking { get; private set; }

        public BookDeliveryRequestDto(string apiKey, string name, string phone, string address)
        {
            ApiKey = apiKey;
            Booking = new BookingDto(name, phone, address);
        }

        public class BookingDto
        {
            public DetailDto PickupDetail { get; private set; }
            public DetailDto DropoffDetail { get; private set; }

            public BookingDto(string name, string phone, string address)
            {
                PickupDetail = new DetailDto(name, phone, address);
                DropoffDetail = new DetailDto(string.Empty, string.Empty, "57 luscombe st, brunswick, melbourne");
            }

            public class DetailDto
            {
                public string Name { get; private set; }
                public string Phone { get; private set; }
                public string Address { get; private set; }

                public DetailDto(string name, string phone, string address)
                {
                    Name = name;
                    Phone = phone;
                    Address = address;
                }
            }
        }
    }
}