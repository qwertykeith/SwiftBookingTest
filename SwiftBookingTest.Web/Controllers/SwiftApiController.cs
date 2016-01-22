using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using SwiftBookingTest.Core.Clients;
using SwiftBookingTest.Core.Clients.ServiceModels;
using SwiftBookingTest.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.IO;

namespace SwiftBookingTest.Web.Controllers
{
    public class SwiftApiController : Controller
    {
        private readonly IClientService _clientService;

        public SwiftApiController(IClientService clientService)
        {
            if (clientService == null)
            {
                throw new ArgumentNullException("clientService");
            }

            _clientService = clientService;
        }

        [HttpGet]
        public async Task<JsonResult> BookDelivery(Guid id)
        {
            var response = _clientService.GetClient(new GetClientRequest(id));

            if (response.Success)
            {
                var swiftApiBaseUrl = ConfigurationManager.AppSettings["SwiftApiBaseUrl"];
                var swiftApiMerchantKey = ConfigurationManager.AppSettings["SwiftApiMerchantKey"];

                var deliveryBookingRequest = new SwiftDeliveryBookingRequestModel
                {
                    ApiKey = swiftApiMerchantKey,
                    Booking = new SwiftBooking
                    {
                        PickupDetail = new SwiftDetail
                        {
                            Name = "David Bowie",
                            Phone = "0354421895",
                            Address = "147 Queen St, Bendigo, Victoria, Australia"
                        },
                        DropoffDetail = new SwiftDetail
                        {
                            Name = response.Client.Name,
                            Phone = response.Client.Phone,
                            Address = response.Client.Address
                        }
                    }
                };                

                var httpClient = new HttpClient() { BaseAddress = new Uri(swiftApiBaseUrl) };
                var apiResponse = await httpClient.PostAsJsonAsync("/api/v2/deliveries", deliveryBookingRequest);

                if (apiResponse.IsSuccessStatusCode)
                {                    
                    dynamic apiResponseContent = await apiResponse.Content.ReadAsAsync<dynamic>();
                    string serialized = JsonConvert.SerializeObject(apiResponseContent, Formatting.Indented);

                    return Json(serialized.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;"), JsonRequestBehavior.AllowGet);
                }                                
            }

            return Json(new { Message = "Error processing request" }, JsonRequestBehavior.AllowGet);
        }
    }
}