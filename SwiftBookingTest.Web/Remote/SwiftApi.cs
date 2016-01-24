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
        //Hard-coded for testing purposes
        const string MerchantKey = "3285db46-93d9-4c10-a708-c2795ae7872d";

        public static string SubmitBookingRequest(BookingDataModel booking)
        {
            var client = new RestClient("https://app.getswift.co/");
            var request = new RestRequest("api/v2/deliveries", Method.POST);

            request.RequestFormat = DataFormat.Json;

            //Ideally these parameters would be encapsulated in an object and then just serialised.
            request.AddBody(new
                {
                    apiKey = MerchantKey,
                    booking = new
                    {
                        pickupDetail = new
                        { //Test Pickup details are hardcoded
                            name = "Test",
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