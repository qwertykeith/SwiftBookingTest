using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwiftBookingTest.Core.Common
{
    public abstract class ServiceResponseBase
    {
        public Exception Exception { get; set; }
        public virtual bool Success { get { return Exception == null; } }
    }
}
