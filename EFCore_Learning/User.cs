using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Learning
{
    public class User
    {
        string name;
        public int Id { get; set; }
        // Необязательно использовать автосвойства, можно и с полноценными блоками get, set
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age { get; set; }
        [NotMapped] // Исключение свойства при помощи аннотации
        public string? Address { get; set; }
    }
}
