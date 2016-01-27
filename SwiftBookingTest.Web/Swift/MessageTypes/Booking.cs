using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Web.Swift.MessageTypes
{
    public class Item
    {
        public int quantity { get; set; }
        public string sku { get; set; }
        public string description { get; set; }
        public double price { get; set; }
    }

    public class AdditionalAddressDetails
    {
        public string stateProvince { get; set; }
        public string country { get; set; }
        public string suburbLocality { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class AddressDetail
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string addressComponents { get; set; }
        public string address { get; set; }
        public AdditionalAddressDetails additionalAddressDetails { get; set; }
    }

    public class DropoffWindow
    {
        public string earliestTime { get; set; }
        public string latestTime { get; set; }
    }
    
    public class Booking
    {
        public string reference { get; set; }
        public string deliveryInstructions { get; set; }
        public bool itemsRequirePurchase { get; set; }
        public List<Item> items { get; set; }
        public string pickupTime { get; set; }
        public AddressDetail pickupDetail { get; set; }
        public DropoffWindow dropoffWindow { get; set; }
        public AddressDetail dropoffDetail { get; set; }
        public double customerFee { get; set; }
        public string customerReference { get; set; }
        public double tax { get; set; }
        public bool taxInclusivePrice { get; set; }
        public double tip { get; set; }
        public double driverFeePercentage { get; set; }
        public string driverMatchCode { get; set; }
    }

    public class MerchantDeliveryBooking
    {
        public Guid apiKey { get; set; }
        public Booking booking { get; set; }
    }
}
