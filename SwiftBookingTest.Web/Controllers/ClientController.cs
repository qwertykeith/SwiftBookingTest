using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SwiftBookingTest.Core.Clients;
using SwiftBookingTest.Core.Clients.ServiceModels;
using SwiftBookingTest.Web.Models;

namespace SwiftBookingTest.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _service;

        public ClientController(IClientService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            _service = service;
        }

        [HttpPost]
        public ActionResult Create(ClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _service.CreateClient(new CreateClientRequest(model.Name, model.Phone, model.Address));

                if (response.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}