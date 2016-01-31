using SwiftBookingTest.Model;
using SwiftBookingTest.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwiftBookingTest.Web.Api
{
    public class PeopleController : ApiController
    {
        private IDeliveryService service;

        public PeopleController(IDeliveryService service)
        {
            this.service = service;
        }

        // GET api/<controller>
        public IEnumerable<Person> Get()
        {
            return service.GetPersons();
        }

        // Put api/<controller>
        public HttpResponseMessage Put([FromBody]Person person)
        {
            if (ModelState.IsValid)
            {
                service.AddPerson(person);
                return new HttpResponseMessage(HttpStatusCode.OK);                
            }
            var res = new HttpResponseMessage(HttpStatusCode.BadRequest);
            res.ReasonPhrase = "model not valid";
            return res;
        }
    }
}