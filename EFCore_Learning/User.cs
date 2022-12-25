using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Learning
{
    public class User
    {
        public int Id { get; set; }
        //[MaxLength(50)] // Аннотация для максимальной длинны
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
