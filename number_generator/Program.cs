using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace number_generator
{
    class Program
    {
        const int SIZE = 1000;
        static int[] numbers = new int[SIZE];
        static void Main(string[] args)
        {
            var random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                numbers[i] = random.Next(1, 1000);
                Console.WriteLine(numbers);
            }
        }
    }
}

/* Консольное приложение генерирует набор чисел, состоящий из 1000 элементов.
С помощью механизма потоков нужно найти максимум, минимум, среднее в этом наборе.
для каждой из задач выделите поток. */