using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Asynchrony_in_practice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Имитация соревнований по поднятию шаров Атласа
            var task1 = Start_strongman("Pasha", 3);
            var task2 = Start_strongman("Denis", 4);
            var task3 = Start_strongman("Apollon", 5);

            await Task.WhenAll(task1, task2, task3);

            async Task Start_strongman(String name, int power)
            {
                // name - имя силача
                // power - подъёмная мощность
                Console.WriteLine($"Силач {name} начал соревнования");
                for (int i = 0; i <= 5; i++)
                {
                    await Task.Delay((1000/ power));
                    Console.WriteLine($"Силач {name} поднял {i + 1} шар");                    
                }
                Console.WriteLine($"Силач {name} закончил соревнования.");
                Console.WriteLine("-----------------------------------------");
            }           
        }
    }
}