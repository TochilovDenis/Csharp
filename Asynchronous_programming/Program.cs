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
            PrintName("Tom");
            PrintName("Bob");
            PrintName("Sam");

            void PrintName(string name)
            {
                Thread.Sleep(3000);     // имитация продолжительной работы
                Console.WriteLine(name);
            }

        }
    }
}
