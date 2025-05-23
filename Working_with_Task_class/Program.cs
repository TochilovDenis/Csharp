﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Working_with_Task_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task[] tasks1 = new Task[3]
            //{
            //    new Task(() => Console.WriteLine("First Task")),
            //    new Task(() => Console.WriteLine("Second Task")),
            //    new Task(() => Console.WriteLine("Third Task"))
            // };
            //// запуск задач в массиве
            //foreach (var t in tasks1)
            //    t.Start();

            //Task[] tasks2 = new Task[3];
            //int j = 1;
            //for (int i = 0; i < tasks2.Length; i++)
            //    tasks2[i] = Task.Factory.StartNew(() => Console.WriteLine($"Task {j++}"));

            //Task[] tasks = new Task[3];
            //for (var i = 0; i < tasks.Length; i++)
            //{
            //    tasks[i] = new Task(() =>
            //    {
            //        Thread.Sleep(1000); // эмуляция долгой работы
            //        Console.WriteLine($"Task{i} finished");
            //    });
            //    tasks[i].Start();   // запускаем задачу
            //}
            //Console.WriteLine("Завершение метода Main");

            //Task.WaitAll(tasks); // ожидаем завершения всех задач

            int n1 = 4, n2 = 5;
            Task<int> sumTask = new Task<int>(() => Sum(n1, n2));
            sumTask.Start();

            int result = sumTask.Result;
            Console.WriteLine($"{n1} + {n2} = {result}"); // 4 + 5 = 9

            int Sum(int a, int b) => a + b;

        }
    }
}
