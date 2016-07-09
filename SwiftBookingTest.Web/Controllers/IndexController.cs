using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Web.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class IndexController : MvcBaseController
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

        [MvcLogFilter]
        public async Task<ActionResult> Index()
        {
            return View(await Task.FromResult<object>(null));
        }
    }
}