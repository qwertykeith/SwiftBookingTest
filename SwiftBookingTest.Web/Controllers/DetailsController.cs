using SwiftBookingTest.Domain;
using SwiftBookingTest.Service;
using SwiftBookingTest.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SwiftBookingTest.Web.Controllers
{
    [RoutePrefix("api")]
    public class DetailsController : ApiController
    {
        /// <summary>
        /// Take the details that are submitted, and save them.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("Details")]
        [HttpPost]
        public void Details(DeliveryDetailsViewModel data)
        {
            if (ModelState.IsValid)
            {
                // Could look at doing this with AutoMapper or some other mapping tool, 
                // but I've over engineered this already :)
                DomainStuffIncludingDeliveryDetails model = new DomainStuffIncludingDeliveryDetails();
                model.FirstOfManyDeliveries = new DeliveryDetailsDomain
                {
                    Name = data.Name,
                    Address = data.Address,
                    Phone = data.Phone
                };

                using (IDeliveryService service = new DeliveryService())
                {
                    service.SaveDeliveryDetails(model.FirstOfManyDeliveries);
                }
            }
        }

        /// <summary>
        /// Perform the post to GetSwift from here due to cross origin sharing of resources (CORS) issues doing it from 
        /// Javascript in the browser
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("Deliver")]
        [HttpPost]
        public async Task<IHttpActionResult> Deliver(DeliveryDetailsDomain data)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {

                    var response = await client.PostAsJsonAsync("https://app.getswift.co/api/v2/deliveries", new
                    {
                        apikey = ConfigurationManager.AppSettings["GetSwiftMerchantKey"],
                        booking = new
                        {
                            pickupDetail = new { address = "256 St Georges Tce, Perth, Western Australia" },
                            dropoffDetail= new { address = data.Address}
                        }
                
                    });

                    return Ok( await response.Content.ReadAsStringAsync());
                }
            }
            return BadRequest();
        }

        /// <summary>
        /// Load historical details to show.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [Route("Details")]
        [HttpGet]
        public List<DeliveryDetailsDomain> Details()
        {
            List<DeliveryDetailsDomain> deliveries = new List<DeliveryDetailsDomain>();
            using (IDeliveryService service = new DeliveryService())
            {
                deliveries = service.GetStuffThatHasBeenDelivered();
            }

            return deliveries;
        }

        /// <summary>
        /// Convenience method to map objects
        /// Again, this is unnecessary, and could be handled by a mapping tool/layer. 
        /// </summary>
        /// <param name="domainObjects">Objects that belong to the domain model</param>
        /// <returns></returns>
        private List<DeliveryDetailsViewModel> Convert(List<DeliveryDetailsDomain> domainObjects)
        {
            List<DeliveryDetailsViewModel> returnData = new List<DeliveryDetailsViewModel>();
            foreach (var val in domainObjects)
            {
                returnData.Add(new DeliveryDetailsViewModel
                {
                    Name = val.Name,
                    Address = val.Address,
                    Phone = val.Phone
                });
            }
            return returnData;
        }

    }
}
