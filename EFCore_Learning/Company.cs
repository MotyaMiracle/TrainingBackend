﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; } // Название компании
        public List<User> Users { get; set; } = new();

    }
}