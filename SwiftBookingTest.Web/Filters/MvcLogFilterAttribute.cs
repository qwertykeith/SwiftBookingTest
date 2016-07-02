using SwiftBookingTest.Core;
using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Filters
{
    public class MvcLogFilterAttribute : ActionFilterAttribute
    {
        public ISwiftDemoUow uow { get; set; }
        public MvcLogFilterAttribute()
        {

        }
        public MvcLogFilterAttribute(ISwiftDemoUow _uow)
        {
            this.uow = _uow;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var gg = uow;
            base.OnActionExecuting(filterContext);
        }
    }
}