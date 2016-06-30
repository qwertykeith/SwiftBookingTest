using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class IndexController : Controller
    {
        public IndexController()
        {

        }
        protected ISwiftDemoUow sdUow { get; set; }
        protected ISwiftBookingBusinessEngineUow buow { get; set; }

        public IndexController(ISwiftDemoUow uow, IIdentity identity)
        {
            sdUow = uow;
        }
        // GET: Index
        public ActionResult Index()
        {
            return View();
        }
    }
}