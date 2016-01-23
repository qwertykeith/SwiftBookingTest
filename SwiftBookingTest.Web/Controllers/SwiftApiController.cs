using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
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