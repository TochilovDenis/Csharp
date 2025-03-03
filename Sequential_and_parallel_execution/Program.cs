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
            // определяем и запускаем задачи
            var task1 = PrintAsync("Hello C#");
            var task2 = PrintAsync("Hello World");
            var task3 = PrintAsync("Hello METANIT.COM");

            // ожидаем завершения хотя бы одной задачи
            await Task.WhenAny(task1, task2, task3);

            async Task PrintAsync(string message)
            {
                await Task.Delay(new Random().Next(1000, 2000));     // имитация продолжительной операции
                Console.WriteLine(message);
            }
        }
    }
}
