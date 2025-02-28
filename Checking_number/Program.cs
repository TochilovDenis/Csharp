using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Checking_number
{
    class Program
    {
        static void Main(string[] args)
        {
            /*  1 Создаем функцию для проверки является ли число простым
                2 используем Parallel.For(int a, int b, Action<int>) для нахождения простых чисел от a до b*/

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            ParallelLoopResult result = Parallel.For(1, 10000, prime_number);

            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");

            // вычисляем квадрат числа


            void prime_number(int n)
            {

                int res = 0;

                for (int i = 1; i < n + 1; i++)
                {
                    if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                    {
                        return;     //  выходим из метода и тем самым завершаем задачу
                    }

                    if (n % i == 0)
                    {
                        res += 1;
                    }
                }

                if (res == 2)
                {
                    Console.WriteLine($"Простое число : {n}");

                    cancelTokenSource.Cancel();
                }

            }
        }
    }
}
