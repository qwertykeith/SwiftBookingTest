using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwiftBookingTest.Web.Controllers;
using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Web.Test.Fakes;
using System.Collections.Generic;
using SwiftBookingTest.Model;

using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using Newtonsoft.Json;
using System.Web.Http.Results;
using Moq;

namespace SwiftBookingTest.Web.Test
{
    /// <summary>
    /// Test class for Clients controller api
    /// </summary>
    [TestClass]
    public class ClientsControllerTest
    {


        private FakeDemoUow _repo;
        private ClientsController _ctrl;


        [TestInitialize]
        public void Init()
        {
            _repo = new FakeDemoUow();

        }


        /// <summary>
        /// Test method for get all
        /// </summary>
        [TestMethod]
        public void GetTest()
        {
            var repo = new Mock<ISwiftDemoUow>();
            _ctrl = new ClientsController(repo.Object);

            List<ClientRecord> cl = new List<ClientRecord>();
            cl.Add(new ClientRecord { Id = 1, Name = "asas" });
            repo.Setup(r => r.ClientRecords.GetAll()).Returns(cl.AsQueryable());

            var kk = ((OkNegotiatedContentResult<IEnumerable<ClientRecord>>)(_ctrl.Get().Result)).Content;
            Assert.IsTrue(cl.SequenceEqual(kk));
        }

        /// <summary>
        /// Posts the test.
        /// </summary>
        [TestMethod]
        public void PostTest()
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/v1/topics");
            var route = config.Routes.MapHttpBatchRoute("DefaultApi", "api/{controller}/{id}", null);
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "topics" } });

            _ctrl.ControllerContext = new HttpControllerContext(config, routeData, request);
            _ctrl.Request = request;
            _ctrl.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            ClientRecord cRec = new ClientRecord
            {
                Address = "21, Test Street, Test Suburb, 5023",
                Name = "Test Name",
                ClientPhones = new List<ClientPhone> { new ClientPhone { PhoneNumber = new PhoneNumber { Number = "123456" } } }
            };

            var result = _ctrl.Post(cRec);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

            var json = result.Content.ReadAsStringAsync().Result;
            var topic = JsonConvert.DeserializeObject<ClientRecord>(json);

            Assert.IsNotNull(topic);
        }
    }
}
