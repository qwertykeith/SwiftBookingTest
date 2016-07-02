using SwiftBookingTest.CoreContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SwiftBookingTest.Web.Filters
{
    public interface IMaxLengthActionFilter : System.Web.Http.Filters.IActionFilter
    {
    }

    public class MaxLengthActionFilter : IMaxLengthActionFilter
    {
        public readonly ISwiftDemoUow _uow;

        public MaxLengthActionFilter(ISwiftDemoUow uow)
        {
            if (uow == null)
                throw new ArgumentNullException("configProvider");
            _uow = uow;
        }

        public Task<HttpResponseMessage> ExecuteActionFilterAsync(
            HttpActionContext actionContext,
            CancellationToken cancellationToken,
            Func<Task<HttpResponseMessage>> continuation)
        {
            var attribute = this.GetMaxLengthAttribute(filterContext.ActionDescriptor);
            if (attribute != null)
            {
                var maxLength = attribute.MaxLength;
                // Execute your behavior here (before the continuation), 
                // and use the configProvider as needed

                return continuation().ContinueWith(t =>
                {
                    // Execute your behavior here (after the continuation), 
                    // and use the configProvider as needed

                    return t.Result;
                });
            }
            return continuation();
        }

        public bool AllowMultiple
        {
            get { return true; }
        }

        public MaxLengthAttribute GetMaxLengthAttribute(ActionDescriptor actionDescriptor)
        {
            MaxLengthAttribute result = null;

            // Check if the attribute exists on the action method
            result = (MaxLengthAttribute)actionDescriptor
                .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .SingleOrDefault();

            if (result != null)
            {
                return result;
            }

            // Check if the attribute exists on the controller
            result = (MaxLengthAttribute)actionDescriptor
                .ControllerDescriptor
                .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                .SingleOrDefault();

            return result;
        }
    }
}