using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwiftBookingTest.Web.Controllers;
using SwiftBookingTest.CoreContracts;
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
using SwiftBookingTest.Core.Helpers;
using SwiftBookingTest.Core;

namespace SwiftBookingTest.Web.Test
{
    /// <summary>
    /// Test class for Clients controller api
    /// </summary>
    [TestClass]
    public class ClientsControllerTest
    {


        private ClientsController _ctrl;


        [TestInitialize]
        public void Init()
        {

        }


        /// <summary>
        /// Test method for get all
        /// </summary>
        [TestMethod]
        public void GetTest()
        {
            var repo = new Mock<ISwiftDemoUow>();
            var coreRepoObject = repo.Object;
            _ctrl = new ClientsController(coreRepoObject);
            List<ClientRecord> cl = new List<ClientRecord>();
            cl.Add(new ClientRecord { Id = 1, Name = "Atul" });
            cl.Add(new ClientRecord { Id = 2, Name = "Kapil" });
            List<OfficeAssignment> ass = new List<OfficeAssignment> {
                new OfficeAssignment {
                    Instructor = new Instructor { InstructorID = 1 }, InstructorID = 1 }
            };
            repo.Setup(r => r.OfficeAssignments.GetByInstructor(1)).Returns(ass.AsQueryable());
            repo.Setup(r => r.ClientRecords.GetAll()).Returns(cl.AsQueryable());
            var kk = ((OkNegotiatedContentResult<IEnumerable<ClientRecord>>)(_ctrl.Get().Result)).Content;
            Assert.IsTrue(cl.SequenceEqual(kk));
        }

        /// <summary>
        /// Posts the test.
        /// </summary>
        [TestMethod]
        [TestCategory("Post with http call")]
        public void PostTest()
        {
            var repo = new Mock<ISwiftDemoUow>();
            var businessEngine = new Mock<ISwiftBookingBusinessEngineUow>();

            List<ClientRecord> cl = new List<ClientRecord>();
            //_ctrl = new ClientsController(repo.Object, businessEngine.Object);
            _ctrl = new ClientsController(repo.Object);

            ClientRecord cRec = new ClientRecord
            {
                Address = "21, Test Street, Test Suburb, 5023",
                Name = "Test Name",
                ClientPhones = new List<ClientPhone> { new ClientPhone { PhoneNumber = new PhoneNumber { Number = "123456" } } }
            };

            repo.Setup(r => r.ClientRecords.Add(cRec));

            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/v1/topics");
            var route = config.Routes.MapHttpBatchRoute("DefaultApi", "api/{controller}/{id}", null);
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "topics" } });

            _ctrl.ControllerContext = new HttpControllerContext(config, routeData, request);
            _ctrl.Request = request;
            _ctrl.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            var result = _ctrl.Post(cRec);
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);

            var json = result.Content.ReadAsStringAsync().Result;
            var topic = JsonConvert.DeserializeObject<ClientRecord>(json);

            Assert.IsNotNull(topic);
        }


    }
}
