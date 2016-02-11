﻿using SwiftBookingTest.Domain;
using SwiftBookingTest.Web.Models;
using SwiftBookingTest.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Take the details that are submitted, and save them.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDetails(DeliveryDetailsViewModel data)
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
                return View("Details");
            }
            return View("Details");
        }

        /// <summary>
        /// Load historical details to show.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details()
        {
            List<DeliveryDetailsDomain> deliveries = new List<DeliveryDetailsDomain>();
            using (IDeliveryService service = new DeliveryService())
            {
                deliveries = service.GetStuffThatHasBeenDelivered();
            }
            
            return View("Index");
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
            foreach(var val in domainObjects )
            {
                returnData.Add(new DeliveryDetailsViewModel {
                    Name = val.Name,
                    Address = val.Address,
                    Phone = val.Phone});
            }
            return returnData;
        }
    }
}
