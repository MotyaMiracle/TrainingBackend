using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Learning
{
    //[Index("PhoneNumber")] //Создание индексов
    //[Index("PhoneNumber", "Passport")] //Создание индексов нескольким свойствам
    //[Index("PhoneNumber", IsUnique = true, Name = "Phone_index")] // Настройка имени и уникальности индекса
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Passport { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
