using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Returning_a_result_from_an_asynchronous_method
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var result = await AddAsync(4, 5);
            Console.WriteLine(result);

            Task<int> AddAsync(int a, int b)
            {
                return Task.FromResult(a + b);
            }
        }
    }
}
