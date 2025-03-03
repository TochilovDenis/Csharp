using System;
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
            await PrintNameAsync("Tom");
            await PrintNameAsync("Bob");
            await PrintNameAsync("Sam");

            // определение асинхронного метода
            async Task PrintNameAsync(string name)
            {
                // Thread.Sleep(3000);      // имитация продолжительной работы
                await Task.Delay(3000);     // имитация продолжительной работы
                Console.WriteLine(name);
            }

        }
    }
}
