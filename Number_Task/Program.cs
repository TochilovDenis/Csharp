using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            Task number = Task.Run(() =>
            {
                for (int i = 2; i < 1001; i++)
                {
                    int res = 0;
                    for (int j = 2; j * j <= i; j++)
                    {
                        if (i % j == 0)
                        {
                            res += 1;
                        }
                    }
                    if (res == 2)
                    {
                        Console.WriteLine($"Number : {i}");
                    }
                }
            });
            number.Wait();
            Console.WriteLine("End main");
        }
    }
}