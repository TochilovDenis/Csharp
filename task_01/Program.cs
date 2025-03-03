using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] age = {1, 2, 5, 111, 3, 5, 9, 28, 5, 28, 1 };

            var selectPeople = age.Distinct();

            foreach (int a in selectPeople)
                Console.WriteLine(a);
        }
    }
}
