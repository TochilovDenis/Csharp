using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Returning_a_result_from_an_asynchronous_method
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await PrintAsync("Hello Metanit.com");

            // определение асинхронного метода
            async Task PrintAsync(string message)
            {
                await Task.Delay(1000);     // имитация продолжительной работы
                Console.WriteLine(message);
            }
        }
    }
}
