using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Parallel_programming_and_the_TPL_library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Starts");
            Task task1 = Task.Run(() =>
            {
                Console.WriteLine($"Task {Task.CurrentId} Starts");
                Thread.Sleep(1000);
                Console.WriteLine($"Task {Task.CurrentId} Ends");
            });
            Console.WriteLine($"Task Id: {task1.Id}");
            Console.WriteLine($"Task Is Completed: {task1.IsCompleted}");
            Console.WriteLine($"Task.Status: {task1.Status}");

            Console.WriteLine("Main Ends");
            task1.Wait();
        }
    }
}
