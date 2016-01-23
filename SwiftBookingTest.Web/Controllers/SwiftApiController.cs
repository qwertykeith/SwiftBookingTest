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
using SwiftBookingTest.Core.Swift;
using SwiftBookingTest.Core.Swift.ServiceModels;
using System.Net;

namespace SwiftBookingTest.Web.Controllers
{
    public class SwiftApiController : Controller
    {
        private readonly ISwiftService _swiftService;

        public SwiftApiController(ISwiftService swiftService)
        {
            if (swiftService == null)
            {
                throw new ArgumentNullException("swiftService");
            }

            _swiftService = swiftService;
        }

        [HttpGet]
        public async Task<JsonResult> BookDelivery(Guid id)
        {
            var pickupDetail = new SwiftDeliveryDetail
            {
                Name = "Chad",
                Phone = "0354431112",
                Address = "234 High St, Bendigo, Victoria, Australia"
            };

            var response = await _swiftService.CreateDeliveryBooking(new CreateDeliveryBookingRequest(id, pickupDetail));

            if (response.Success)
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string serialized = JsonConvert.SerializeObject(response.Content, Formatting.Indented);
                    serialized = serialized.Replace("\r\n", "<br/>").Replace(" ", "&nbsp;");

                    return Json(serialized, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(response.Exception, JsonRequestBehavior.AllowGet);                        
        }
    }
}