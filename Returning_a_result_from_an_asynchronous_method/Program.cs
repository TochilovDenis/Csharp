using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Returning_a_result_from_an_asynchronous_method
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Account account = new Account();
            account.Added += PrintAsync;

            account.Put(500);

            await Task.Delay(2000); // ждем завершения

            // определение асинхронного метода
            async void PrintAsync(object obj, string message)
            {
                await Task.Delay(1000);     // имитация продолжительной работы
                Console.WriteLine(message);
            }
        }
        class Account
        {
            int sum = 0;
            public event EventHandler<string> Added;
            public void Put(int sum)
            {
                this.sum += sum;
                Added?.Invoke(this, $"На счет поступило {sum} $");
            }
        }
    }
}
