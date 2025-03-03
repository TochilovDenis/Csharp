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
            var tomTask = PrintNameAsync("Tom");
            var bobTask = PrintNameAsync("Bob");
            var samTask = PrintNameAsync("Sam");

            await tomTask;
            await bobTask;
            await samTask;

            // определение асинхронного метода
            async Task PrintNameAsync(string name)
            {
                await Task.Delay(3000);     // имитация продолжительной работы
                Console.WriteLine(name);
            }
        }
    }
}
