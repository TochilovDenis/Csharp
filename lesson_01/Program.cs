using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_01
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите дату: ");
            String date = Console.ReadLine();
            DateTime dateTime = Convert.ToDateTime(date);
            Console.WriteLine("Наша дата " + dateTime.ToString("dddd.MMM.yyy"));
        }

        void fizz_puzz()
        {
            Console.WriteLine("Введите число: ");

            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Остаток от деления на 3: {num % 3}");

            if (num <= 0 || num >= 100) Console.WriteLine("Error");
            Console.WriteLine(num % 3 == 0 ? "Fizz" : null);
            Console.WriteLine(num % 5 == 0 ? "Buzz" : null);
            Console.WriteLine(num % 3 != 0 && num % 5 != 0 ? Convert.ToString(num) : null);
        }

        void enter_int() {
            String num = "";
            String mas = "";
            while (true)
            {
                Console.WriteLine("Введите 4 цифры: ");
                num = Console.ReadLine();
                if (num == "end") break;
                mas += num;
            }
            int a = Convert.ToInt32(mas) + 1;
            Console.WriteLine("Число num + 1" + a);
        }
    }
}
