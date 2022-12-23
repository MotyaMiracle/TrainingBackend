using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Learning
{
    [NotMapped] // Аннотация для исключения сущности из модели
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
