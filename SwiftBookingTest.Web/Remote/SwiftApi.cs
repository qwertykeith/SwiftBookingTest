using RestSharp;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Remote
{
    /// <summary>
    /// The following is a utility class that connects to the GetSwift REST api
    /// This relies on the RestSharp library (http://restsharp.org/).
    /// </summary>
    public class SwiftApi
    {
        //Hard-coded settings for demo purposes
        const string MerchantKey = "3285db46-93d9-4c10-a708-c2795ae7872d";
        const string RestServiceURL = "https://app.getswift.co/";
        const string DeliveriesService = "api/v2/deliveries";

        public static string SubmitBookingRequest(BookingDataModel booking)
        {
            var client = new RestClient(RestServiceURL);
            var request = new RestRequest(DeliveriesService, Method.POST);

            request.RequestFormat = DataFormat.Json;

            //Ideally these parameters would be encapsulated in an object and then just serialised.
            request.AddBody(new
                {
                    apiKey = MerchantKey,
                    booking = new
                    {
                        pickupDetail = new
                        { 
                            //Test Pickup details are hardcoded
                            name = "John Doe",
                            phone = "0455555555",
                            address = "99 Bayswater Road, Kensington, Melbourne"
                        },
                        dropoffDetail = new
                        {
                            name = booking.Name,
                            phone = booking.Phone,
                            address = booking.Address
                        }
                    }
                }
            );

            var response = client.Execute(request);

            return response.Content;
        }
    }
}