﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_02
{
    internal class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string name = "Undefined";   // имя
        public int age;                     // возраст

        public void Print()
        {
            Console.WriteLine($"Имя: {name}  Возраст: {age}");
        }
    }
}
