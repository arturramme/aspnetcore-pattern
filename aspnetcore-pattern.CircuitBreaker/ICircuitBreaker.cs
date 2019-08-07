using System;
using System.Collections.Generic;
using System.Text;

namespace aspnetcore_pattern.CircuitBreaker
{
    public interface ICircuitBreaker
    {
        CircuitBreakerState State { get; }
        void Reset();
        void Execute(Action action);
        bool IsClosed { get; }
        bool IsOpen { get; }
    }
}
