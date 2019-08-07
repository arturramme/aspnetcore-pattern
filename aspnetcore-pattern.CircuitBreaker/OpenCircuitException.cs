using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcore_pattern.CircuitBreaker
{
    public class OpenCircuitException : Exception
    {
        public OpenCircuitException(string message) : base(message)
        {

        }
    }

    public class CircuitBreakerOperationException : Exception
    {
        public CircuitBreakerOperationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
