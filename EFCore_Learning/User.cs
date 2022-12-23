﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public Company? Company { get; set; }

        public User(string name)
        {
            Name = name;
            Age = 18;
            Console.WriteLine($"Вызов конструктора для объекта {name}");
        }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
