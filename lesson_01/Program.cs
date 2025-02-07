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
            Console.WriteLine("Введите Ваше Имя: ");
            string name;
            name = Console.ReadLine();
            if (name == "")
                Console.WriteLine("Привет, Мир!!!");
            else
                Console.WriteLine("Привет, " + name + "!");


        }
    }
}
