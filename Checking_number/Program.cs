using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checking_number
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  1 Создаем функцию для проверки является ли число простым
                2 используем Parallel.For(int a, int b, Action<int>) для нахождения простых чисел от a до b*/

            ParallelLoopResult result = Parallel.For(1, 1000, prime_number);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");

            void prime_number(int n)
            {
                int res = 0;
                Console.WriteLine($"Проверяем {n}");
                for (int i = 1; i < n; i++)
                {
                    if (n % i == 0)
                    {
                        res += 1;
                    }
                    if (res == 2)
                    {
                        Console.WriteLine($"Простое число : {n}");
                    }
                }
            }
        }
    }
}
