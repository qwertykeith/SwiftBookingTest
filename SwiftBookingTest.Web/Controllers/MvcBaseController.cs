using SwiftBookingTest.CoreContracts;
using SwiftBookingTest.Web.ActionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class MvcBaseController : Controller
    {
        protected ISwiftDemoUow sdUow { get; set; }
        protected ISwiftBookingBusinessEngineUow buow { get; set; }

        public BetterJsonResult<T> BetterJson<T>(T model, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            return new BetterJsonResult<T>() { Data = model, JsonRequestBehavior = behavior };
        }
    }
}