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
            Console.WriteLine(num % 3 == 0 ? "Fizz" : null);
            Console.WriteLine(num % 5 == 0 ? "Buzz" : null);
            Console.WriteLine(num % 3 != 0 && num % 5 != 0 ? Convert.ToString(num): null);


        }
    }
}
