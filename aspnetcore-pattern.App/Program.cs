using aspnetcore_pattern.CircuitBreaker;
using System;
using System.Diagnostics;

namespace aspnetcore_pattern.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var cb = new CircuitBreaker.CircuitBreaker(5, 3000);
            try
            {
                int count = 0;
                cb.Execute(() =>
                {   
                    try
                    {
                        if (count >= 4)
                        {
                            Console.WriteLine("OK");
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        count++;
                        throw;
                    }                    
                });
            }
            catch (CircuitBreakerOperationException ex)
            {
                Trace.Write(ex);
            }
            catch (OpenCircuitException openEx)
            {
                Console.Write(cb.IsOpen);
            }
            Console.Write(cb.IsClosed);
            Console.Read();
        }
    }
}
