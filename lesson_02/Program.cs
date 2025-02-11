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
            int a = 2;
            int b = 4;
            
            Console.WriteLine(1 + 3);

            String h = calc2(a, b);
            Console.WriteLine(h);

            String calc2(int a1, int b1)
            {
                int x = a1 + b1;

                //String c = Convert.ToString(x);
                //return $"{c}";

                return "Получилось:" + x.ToString() + ". или получилось:" + Convert.ToString(x);
            }
        }

        static String calc(int a, int b) {
            int x = a + b;

            //String c = Convert.ToString(x);
            //return $"{c}";

            return "Получилось"+x.ToString()+". или получилось:"+Convert.ToString(x);
        }
    }
}
