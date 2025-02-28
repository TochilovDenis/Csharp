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
                for (int i = 1; i < 10; i++)
                {
                    if (token.IsCancellationRequested)  // проверяем наличие сигнала отмены задачи
                    {
                        Console.WriteLine("Операция прервана");
                        return;     //  выходим из метода и тем самым завершаем задачу
                    }
                    Console.WriteLine($"Квадрат числа {i} равен {i * i}");
                    Thread.Sleep(200);
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
