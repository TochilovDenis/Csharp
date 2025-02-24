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
        static int maxValue = int.MinValue;

        static readonly object locker = new object();

        static void Main(string[] args)
        {
            
            var random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                numbers[i] = random.Next(1, 10000);
            }

            Thread maxThread = new Thread(FindMaximum);

            maxThread.Start();
            maxThread.Join();
            Console.WriteLine($"Максимальное значение: {maxValue}");
        }


        // Поиск максимальное число
        static void FindMaximum()
        {
            int localMax = int.MinValue;
            for (int i = 0; i < SIZE; i++)
            {
                if (numbers[i] > localMax) localMax = numbers[i];
            }

            lock (locker)
            {
                if (localMax > maxValue) maxValue = localMax;
            }
        }
    }
}

/* Консольное приложение генерирует набор чисел, состоящий из 1000 элементов.
С помощью механизма потоков нужно найти максимум, минимум, среднее в этом наборе.
для каждой из задач выделите поток. */