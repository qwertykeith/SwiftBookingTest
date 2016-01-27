using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Web.Data;
using SwiftBookingTest.Web.Services;
using SwiftBookingTest.Web.Swift;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;

namespace SwiftBookingTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private DeliveryDataAccessor deliveryDataAccessor;
        private DeliveryService deliveryService;

        public HomeController()
        {
            var apiKey = ConfigurationManager.AppSettings["SwiftApiKey"];
            var apiKeyParsed = Guid.Parse(apiKey);
            deliveryDataAccessor = new DeliveryDataAccessor();
            var swiftConnector = new SwiftConnector(apiKeyParsed, new SwiftClient());
            deliveryService = new DeliveryService(swiftConnector, deliveryDataAccessor);
        }

        public ActionResult Index(int? deliveryId = null)
        {
            return View(BuildIndexViewModel(deliveryId));
        }

        [HttpPost]
        public ActionResult CreateDeliveryPoint(DeliveryPoint deliveryPoint)
        {
            if (ModelState.IsValid)
            {
                deliveryDataAccessor.AddDeliveryPoint(deliveryPoint);
                return RedirectToAction("Index");
            }
            var viewModel = BuildIndexViewModel(null);
            viewModel.DeliveryPointToAdd = deliveryPoint;
            return View("Index",viewModel);
            
        }

        [HttpPost]
        public async Task<ActionResult> BookDeliveryAsync(int deliveryPointId)
        {
            var deliveryId = await deliveryService.BookDeliveryAsync(deliveryPointId);

            // We could just show the message on the screen, but by redirecting to index
            // we have a GET request, which means hitting refresh behaves nicely (and the 
            // user can copy and paste the link around).
            return RedirectToAction("Index", new {deliveryId});
        }

        private IndexViewModel BuildIndexViewModel(int? deliveryId)
        {
            using (var context = new Data.SwiftDemoContext())
            {
                var deliveryPoints = deliveryDataAccessor.GetDeliveryPoints();
                string message = String.Empty;
                if (deliveryId.HasValue)
                {
                    var delivery = deliveryDataAccessor.GetDeliveryById(deliveryId.Value);
                    message = delivery.BookingMessage;
                }
                return new IndexViewModel{DeliveryPoints = deliveryPoints, Message = message};
            }
        }

    }
}
