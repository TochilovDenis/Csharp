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
            // Создаем задачу для поиска простых чисел
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Поиск простых чисел от 0 до 1000:");

                // Находим и выводим все простые числа
                for (int i = 0; i <= 1000; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write($"{i} ");
                    }
                }
                Console.WriteLine("\nПоиск завершен!");
            });

            // Ожидаем завершения задачи
            task.Wait();
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}