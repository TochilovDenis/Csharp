using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Continuation_tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> sumTask = new Task<int>(() => Sum(4, 5));

            // задача продолжения
            Task printTask = sumTask.ContinueWith(task => PrintResult(task.Result));

            sumTask.Start();

            // ждем окончания второй задачи
            printTask.Wait();
            Console.WriteLine("Конец метода Main");

            //int Sum(int a, int b) => a + b;
            int Sum(int a, int b) { return a + b; };

            void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");
        }
    }
}
