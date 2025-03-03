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
            var task1 = SquareAsync(4);
            var task2 = SquareAsync(5);
            var task3 = SquareAsync(6);

            // ожидаем завершения всех задач
            int[] results = await Task.WhenAll(task1, task2, task3);
            // получаем результаты:
            foreach (int result in results)
                Console.WriteLine(result);

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(1000);
                return n * n;
            }
        }
    }
}
