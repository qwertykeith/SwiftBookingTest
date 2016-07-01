using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class IndexController : Controller
    {
        protected ISwiftDemoUow sdUow { get; set; }
        protected IIdentity Identity { get; private set; }

        public IndexController()
        {

        }
      
        public IndexController(ISwiftDemoUow uow, IIdentity identity)
        {
             sdUow = uow;
            Identity = identity;
        }

        // GET: Index
        public async Task<ActionResult> Index()
        {
            return View(await Task.FromResult<object>(null));
        }
    }
}