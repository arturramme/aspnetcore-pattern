using aspnetcore_pattern.Command;
using System;

namespace aspnetcore_pattern.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            
            ConcreteCommand command = new ConcreteCommand(receiver);
            
            Invoker invoker = new Invoker();

            invoker.SetCommand(command);
            invoker.ExecuteCommand();

            Console.ReadKey();

            int @operator = 0;
        }
    }
}
