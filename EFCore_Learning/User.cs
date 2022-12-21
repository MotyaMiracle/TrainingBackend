using System;
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
        public bool isMarried { get; set; }
        // public string? Position { get; set; } Новое свойство - должность пользователя
    }
}
