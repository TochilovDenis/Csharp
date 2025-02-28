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
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения - task2 выполняется после task1
            Task task2 = task1.ContinueWith(PrintTask);

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Конец метода Main");


            void PrintTask(Task t)
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
                Console.WriteLine($"Id предыдущей задачи: {t.Id}");
                Thread.Sleep(3000);
            }
        }
    }
}
