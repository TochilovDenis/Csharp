using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Returning_a_result_from_an_asynchronous_method
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var square5 = SquareAsync(5);
            var square6 = SquareAsync(6);

            Console.WriteLine("Остальные действия в методе Main");

            int n1 = await square5;
            int n2 = await square6;
            Console.WriteLine($"n1={n1}  n2={n2}"); // n1=25  n2=36

            async Task<int> SquareAsync(int n)
            {
                await Task.Delay(0);
                var result = n * n;
                Console.WriteLine($"Квадрат числа {n} равен {result}");
                return result;
            }
        }
    }
}
