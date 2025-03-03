using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequential_and_parallel_execution
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PrintAsync("Hello C#");
            await PrintAsync("Hello World");
            await PrintAsync("Hello METANIT.COM");

            async Task PrintAsync(string message)
            {
                await Task.Delay(2000);     // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }
    }
}
