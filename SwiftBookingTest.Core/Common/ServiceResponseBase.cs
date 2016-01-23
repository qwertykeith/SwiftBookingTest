using System;

namespace SwiftBookingTest.Core.Common
{
    public abstract class ServiceResponseBase
    {
        public Exception Exception { get; set; }
        public virtual bool Success { get { return Exception == null; } }
    }
}
