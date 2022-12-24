using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EFCore_Learning
{
    public class User
    {
        public int Id { get; set; }
        [Required] // Аннотация для NOT NULL
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
