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
        static int minValue = int.MaxValue;

        static readonly object locker = new object();

        static void Main(string[] args)
        {
            
            var random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                numbers[i] = random.Next(1, 10000);
            }

            Thread maxThread = new Thread(FindMaximum);
            Thread minThread = new Thread(FindMinimum);


            maxThread.Start();
            minThread.Start();

            maxThread.Join();
            minThread.Join();

            Console.WriteLine($"Максимальное значение: {maxValue}");
            Console.WriteLine($"Минимальное значение: {minValue}");
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

        // Поиск минимальное число
        static void FindMinimum()
        {
            int localMin = int.MaxValue;
            for (int i = 0; i < SIZE; i++)
            {
                if (numbers[i] < localMin) localMin = numbers[i];
            }

            lock (locker)
            {
                if (localMin < minValue) minValue = localMin;
            }
        }

    }
}

/* Консольное приложение генерирует набор чисел, состоящий из 1000 элементов.
С помощью механизма потоков нужно найти максимум, минимум, среднее в этом наборе.
для каждой из задач выделите поток. */