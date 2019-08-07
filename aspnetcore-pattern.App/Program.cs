using aspnetcore_pattern.CircuitBreaker;
using System;
using System.Diagnostics;

namespace aspnetcore_pattern.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CircuitBreakerWithPolly();

            cb.Execute();
        }
    }
}
