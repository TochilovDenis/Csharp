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

            // в другой задаче посылаем сигнал отмены
            new Task(() =>
            {
                Thread.Sleep(400);
                cancelTokenSource.Cancel();
            }).Start();

            try
            {
                Parallel.ForEach<int>(new List<int>() { 1, 2, 3, 4, 5 },
                                            new ParallelOptions { CancellationToken = token }, Square);
                // или так
                //Parallel.For(1, 5, new ParallelOptions { CancellationToken = token }, Square);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Операция прервана");
            }
            finally
            {
                cancelTokenSource.Dispose();
            }

            void Square(int n)
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
            }
        }
    }
}
