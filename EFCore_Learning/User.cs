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
        public int CompanyId { get; set; } // Внешний ключ
        public Company? Company { get; set; } // Навигационное свойство
    }
}
