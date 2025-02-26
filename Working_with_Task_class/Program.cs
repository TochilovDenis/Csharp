using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Working_with_Task_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Task[] tasks1 = new Task[3]
            {
                new Task(() => Console.WriteLine("First Task")),
                new Task(() => Console.WriteLine("Second Task")),
                new Task(() => Console.WriteLine("Third Task"))
             };
            // запуск задач в массиве
            foreach (var t in tasks1)
                t.Start();
        }
    }
}
