using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Basics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

            var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);

            foreach (string person in selectedPeople)
                Console.WriteLine(person);

            int number = (from p in people where p.ToLower().StartsWith("b") select p).Count();
            Console.WriteLine(number); // 2
        }
    }
}
