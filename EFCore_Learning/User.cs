using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore_Learning
{
    [Table("Person")] // Через аннотацию
    public class User
    {
        //[Column("user_id")]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        
    }
}
