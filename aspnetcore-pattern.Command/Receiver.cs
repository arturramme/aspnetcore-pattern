﻿using System;

namespace aspnetcore_pattern.Command
{
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }
}