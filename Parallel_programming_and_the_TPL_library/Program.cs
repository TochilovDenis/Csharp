using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_programming_and_the_TPL_library
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => Console.WriteLine("Hello Task!"));
            task.Start();
            task.Wait();

        }
    }
}
