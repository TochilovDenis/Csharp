using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task__Time_and_Date
{
    class Program
    {
        static void Main(string[] args)
        {
            Task current_time_1 = new Task(() =>
            {
                Console.WriteLine($"Time new Task: {DateTime.Now}");
            });
            current_time_1.Start();

            Task current_time_2 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"Time Task.Factory.StartNew: {DateTime.Now}");
            });

            Task current_time_3 = Task.Run(() =>
            {
                Console.WriteLine($"Time Task.Run: {DateTime.Now}");
            });

            current_time_1.Wait();
            current_time_2.Wait();
            current_time_3.Wait();
        }
    }
}
