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
            Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}"));

            // задача продолжения
            Task task2 = task1.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

            Task task3 = task2.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));


            Task task4 = task3.ContinueWith(t => Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

            task1.Start();

            task4.Wait();   //  ждем завершения последней задачи
            Console.WriteLine("Конец метода Main");
        }
    }
}
