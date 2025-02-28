using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Class_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(1, 5, Square);

            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
                Thread.Sleep(2000);
            }
        }
    }
}
