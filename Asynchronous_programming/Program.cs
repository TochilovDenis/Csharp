﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Asynchronous_programming
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // асинхронное лямбда-выражение
            Func<string, Task> printer = async (message) =>
            {
                await Task.Delay(1000);
                Console.WriteLine(message);
            };

            await printer("Hello World");
            await printer("Hello METANIT.COM");
        }
    }
}
