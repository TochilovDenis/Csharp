using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person Denis = new Person();

            Denis.name = "Денис";
            Denis.age = 34;
            Denis.Print();
        }

    }
}
