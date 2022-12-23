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
        [Column("user_id")] // Column("user_id") означает что свойство Id будет сопоставляться со столбцом "user_id"
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
    }
}
