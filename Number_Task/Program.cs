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
            Console.Write("Введите нижнюю границу: ");
            int lowerBound = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите верхнюю границу: ");
            int upperBound = Convert.ToInt32(Console.ReadLine());

            // Создаем задачу для поиска простых чисел
            Task<int> task = Task.Run(() =>
            {
                Console.WriteLine($"Поиск простых чисел от {lowerBound} до {upperBound}:");

                // Находим все простые числа в диапазоне и считаем их количество
                int count = 0;
                for (int i = lowerBound; i <= upperBound; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write($"{i} ");
                        count++;
                    }
                }
                Console.WriteLine("\nПоиск завершен!");
                return count;
            });

            // Ожидаем завершения задачи и получаем результат
            int primeCount = task.Result;

            Console.WriteLine($"\nНайдено {primeCount} простых чисел.");
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