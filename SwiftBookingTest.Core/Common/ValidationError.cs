using System;

namespace SwiftBookingTest.Core.Common
{
    public class ValidationError
    {
        public ValidationError(string message, string code = null)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentException("Cannot be null, empty or whitespace", nameof(message));
            }

            Message = message;
            Code = code;
        }

        public string Code { get; private set; }
        public string Message { get; private set; }
    }
}
