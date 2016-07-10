using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SwiftBookingTest.Web.Controllers
{
    public class TemplateController : MvcBaseController
    {
        public async Task<ActionResult> Render(string feature, string name)
        {
            return (PartialView(await Task.FromResult<string>($"~/scripts/app/{feature}/templates/{name}")));
        }
    }
}