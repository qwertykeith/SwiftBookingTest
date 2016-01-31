using Newtonsoft.Json.Linq;
using SwiftBookingTest.Model;
using SwiftBookingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace SwiftBookingTest.Web.Api
{
    public class DeliveryController : ApiController
    {
        private IDeliveryService service;

        public DeliveryController(IDeliveryService service)
        {
            this.service = service;
        }

        // POST api/<controller>/book
        [HttpPost]
        public async Task<string> Book([FromBody]JObject booking)
        {
            var pickup = booking["pickup"].ToObject<Person>();
            var dropoff = booking["dropoff"].ToObject<Person>();
            return await service.Book(pickup, dropoff);
        }        
    }
}