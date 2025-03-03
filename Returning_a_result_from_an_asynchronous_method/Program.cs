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
            var task = PrintAsync("Hello Metanit.com"); // задача начинает выполняться
            Console.WriteLine("Main Works");

            await task; // ожидаем завершения задачи

            // определение асинхронного метода
            async Task PrintAsync(string message)
            {
                await Task.Delay(3000);
                Console.WriteLine(message);
            }
        }
    }
}
