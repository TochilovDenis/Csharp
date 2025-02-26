using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Working_with_Task_class
{
    class Program
    {
        static void Main(string[] args)
        {
            var outer = Task.Factory.StartNew(() =>      // внешняя задача
            {
                Console.WriteLine("Outer task starting...");
                var inner = Task.Factory.StartNew(() =>  // вложенная задача
                {
                    Console.WriteLine("Inner task starting...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Inner task finished.");
                });
            });
            outer.Wait(); // ожидаем выполнения внешней задачи
            Console.WriteLine("End of Main");
        }
    }
}
