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

            //слово async, которое указывается в определении метода, НЕ делает автоматически метод асинхронным.
            //Оно лишь указывает, что данный метод может содержать одно или несколько выражений await.

            Console.WriteLine("Начало выполнения программы");

            await PrintAsync();

            Console.WriteLine("Конец выполнения программы");


            void Print()
            {
                Thread.Sleep(10000);
                Console.WriteLine("Метод Print");
            }

            async Task PrintAsync()
            {
                Console.WriteLine("Начало метода PrintAsync");

                await Task.Run(Print);
                
                Console.WriteLine("Конец метода PrintAsync");
            }
        }
    }
}
