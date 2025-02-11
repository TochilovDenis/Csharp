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
            test(n);
        }

        static void test(int n)
        {
            if (n == 20) return ;

            n++;
            Console.WriteLine(n);   
            test(n);
        }
    }
}
