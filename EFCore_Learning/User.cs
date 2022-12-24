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
        //[DatabaseGenerated(DatabaseGeneratedOption.None)] Для отключения Идентификатора (чтобы не увеличивалось автоматически на 1)
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)] Избыточно для Id, так как автоматически Identity
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        //public DateTime CreateAt { get; set; }
    }
}
