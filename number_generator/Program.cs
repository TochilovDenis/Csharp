using System;
using System.Collections.Generic;
using System.IO;
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
        static long sum = 0;
        static readonly object locker = new object();

        static readonly object fileLocker = new object();
        static volatile bool fileWritingCompleted = false;


        static void Main(string[] args)
        {

            var random = new Random();
            for (int i = 0; i < SIZE; i++)
            {
                numbers[i] = random.Next(1, 10000);
            }

            Task maxTask = Task.Run(() => FindMaximum());
            Task minTask = Task.Run(() => FindMinimum());
            Task avgTask = Task.Run(() => FindAverage());

            // Ждем завершения всех вычислительных задач
            Task.WaitAll(maxTask, minTask, avgTask);

            // Устанавливаем флаг завершения
            fileWritingCompleted = true;

            // Записываем результаты в файл
            WriteToFile();


            Console.WriteLine($"Максимальное значение: {maxValue}");
            Console.WriteLine($"Минимальное значение: {minValue}");
            Console.WriteLine($"Среднее значение: {sum / SIZE:F2}");
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

        // Поиск среднее значение
        static void FindAverage()
        {
            long localSum = 0;

            for (int i = 0; i < SIZE; i++)
            {
                localSum += numbers[i];
            }

            lock (locker)
            {
                sum += localSum;
            }
        }

        static void WriteToFile()
        {
            string filePath = "results.txt";

            // Ожидаем завершения вычислений
            while (!fileWritingCompleted)
            {
                Thread.Sleep(100);
            }

            lock (fileLocker)
            {
                try
                {
                    using (StreamWriter writer = File.CreateText(filePath))
                    {
                        writer.WriteLine("Массив чисел:");
                        foreach (var number in numbers)
                        {
                            writer.WriteLine(number);
                        }
                        writer.WriteLine("\nРезультаты вычислений:");
                        writer.WriteLine($"Максимальное значение: {maxValue}");
                        writer.WriteLine($"Минимальное значение: {minValue}");
                        writer.WriteLine($"Среднее значение: {sum / SIZE:F2}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при записи в файл: {ex.Message}");
                }
            }
        }
    }
}

/* Консольное приложение генерирует набор чисел, состоящий из 1000 элементов.
С помощью механизма потоков нужно найти максимум, минимум, среднее в этом наборе.
для каждой из задач выделите поток.

 Добавьте поток, выводящий набор чисел и результаты вычислений в файл*/