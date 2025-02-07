using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Остаток от деления на 3: {num%3}");
            if (num <= 0 || num >= 100) Console.WriteLine("Error");

            if (num % 3 == 0) Console.WriteLine("Fizz");
            else Console.WriteLine("Buzz");
        }
    }
}
