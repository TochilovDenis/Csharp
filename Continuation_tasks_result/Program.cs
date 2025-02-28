using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Continuation_tasks_result
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> Tasks = new Task<int>(() => Square(2));

            Task<int> Tasks_1 = Tasks.ContinueWith(task => Square(task.Result));
            Task<int> Tasks_2 = Tasks_1.ContinueWith(task => Square(task.Result));
            Task<int> Tasks_3 = Tasks_2.ContinueWith(task => Square(task.Result));

            Tasks.Start();
            Tasks_3.Wait();
            Console.WriteLine(Tasks_3.Result);

            int Square(int a)
            {
                Console.WriteLine(a);
                return a* a;
            };
          
        }       
    }
}
