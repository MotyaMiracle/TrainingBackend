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
        //В качестве ключа используется свойство, которое называется Id или [имя_класса]Id
        /*public int Id { get; set; }
        public int UserId { get; set; }*/
        //[Key] // Установка первичного ключа при помощи аннотации
        public int Identy { get; set; }
        //public string? PassportSeria { get; set; }
        //public string? PassportNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Passport { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
