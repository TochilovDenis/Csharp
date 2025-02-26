using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_programming_and_the_TPL_library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("Task Starts");
                Thread.Sleep(1000);     // задержка на 1 секунду - имитация долгой работы
                Console.WriteLine("Task Ends");
            });
            task1.Wait();   // ожидаем выполнения задачи
            Console.WriteLine("Main Ends");
        }
    }
}
