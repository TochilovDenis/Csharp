using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cancellation_Token
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // задача вычисляет квадраты чисел
            Task task = new Task(() =>
            {
                int i = 1;
                token.Register(() =>
                {
                    Console.WriteLine("Операция прервана");
                    i = 10;
                });
                for (; i < 10; i++)
                {
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(400);
                }
            }, token);
            task.Start();

            Thread.Sleep(1000);
            // после задержки по времени отменяем выполнение задачи
            cancelTokenSource.Cancel();
            // ожидаем завершения задачи
            Thread.Sleep(1000);
            //  проверяем статус задачи
            Console.WriteLine($"Task Status: {task.Status}");
            cancelTokenSource.Dispose(); // освобождаем ресурсы
        }
    }
}
