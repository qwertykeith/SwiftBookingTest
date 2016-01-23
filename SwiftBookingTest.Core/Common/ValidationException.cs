using System;
using System.Collections.Generic;

namespace SwiftBookingTest.Core.Common
{
    public class ValidationException : Exception
    {
        public ValidationException()
        {
        }

        public ValidationException(IEnumerable<ValidationError> errors)
        {
            ValidationErrors = errors;
        }

        public ValidationException(string message) : base(message)
        {
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public IEnumerable<ValidationError> ValidationErrors { get; private set; }
    }
}
