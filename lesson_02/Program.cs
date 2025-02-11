using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine(Factorial(n));
  
        }

        static int Factorial(int n)
        {
            if (n == 1) return 1;

            int c = n * Factorial(n - 1);
            Console.WriteLine(c);

            return c;
        }
    }
}
