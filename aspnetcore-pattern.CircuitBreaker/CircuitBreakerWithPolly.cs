using Polly;
using Polly.CircuitBreaker;
using System;
using System.IO;
using System.Net;
using System.Threading;

namespace aspnetcore_pattern.CircuitBreaker
{
    public class CircuitBreakerWithPolly
    {
        public void Execute()
        {
            var retry = Policy.Handle<WebException>().WaitAndRetryForever(attemp => TimeSpan.FromMilliseconds(300));
            var circuitBreakerPolicy = Policy.Handle<WebException>().CircuitBreaker(3, TimeSpan.FromSeconds(15), onBreak: (ex, timespan, context) =>
            {
                Console.WriteLine("Circuito entrou em estado de falha");
            }, onReset: (context) =>
            {
                Console.WriteLine("Circuito saiu do estado de falha");
            });

            while (true)
            {
                retry.Execute(() =>
                {
                    if (circuitBreakerPolicy.CircuitState != CircuitState.Open)
                    {
                        circuitBreakerPolicy.Execute(() =>
                        {

                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost");

                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            using (Stream stream = response.GetResponseStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                var html = reader.ReadToEnd();
                                Console.WriteLine("Requisição feita com sucesso");
                                Thread.Sleep(300);
                            }

                        });
                    }
                });
            }
        }
    }
}
