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
    public class HomeController : Controller
    {
        private readonly IClientService _service;

        public HomeController(IClientService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service");
            }

            _service = service;
        }

        public ActionResult Error()
        {
            return View();
        }

        public ActionResult Index()
        {
            var response = _service.GetClients();

            if (!response.Success)
            {
                return RedirectToAction("Error");
            }

            var model = new HomeViewModel
            {
                NewClient = TempData["NewClient"] as ClientViewModel ?? new ClientViewModel(),
                Clients = response.Clients
                    .Select(x => new ClientViewModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Phone = x.Phone,
                        Address = x.Address
                    })
            };                       

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateClient(HomeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _service.CreateClient(new CreateClientRequest(model.NewClient.Name, model.NewClient.Phone, model.NewClient.Address));

                if (response.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            TempData["NewClient"] = model.NewClient;

            return RedirectToAction("Index");
        }
    }
}
