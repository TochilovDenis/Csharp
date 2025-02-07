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
            Console.WriteLine("Введите число: ");

            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Остаток от деления на 3: {num%3}");

            if (num <= 0 || num >= 100) Console.WriteLine("Error");
            else if (num % 3 == 0) Console.WriteLine("Fizz");
            else if (num % 5 == 0) Console.WriteLine("Buzz");
            else if (num % 3 != 0 && num % 5 != 0) Console.WriteLine(num);

        }
    }
}
