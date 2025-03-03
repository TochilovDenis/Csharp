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
            Console.WriteLine("Начало выполнения программы");

            PrintAsync();

            Console.WriteLine("Конец выполнения программы");


            void Print()
            {
                Thread.Sleep(10000);
                Console.WriteLine("Метод Print");
            }

            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода PrintAsync");

                Task.Run(Print);
                
                Console.WriteLine("Конец метода PrintAsync");
            }
        }
    }
}
