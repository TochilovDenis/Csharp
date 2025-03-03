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
            PrintAsync("Hello World");
            PrintAsync("Hello METANIT.COM");

            Console.WriteLine("Main End");
            await Task.Delay(3000); // ждем завершения задач

            // определение асинхронного метода
            async void PrintAsync(string message)
            {
                await Task.Delay(1000);     // имитация продолжительной работы
                Console.WriteLine(message);
            }
        }
    }
}
