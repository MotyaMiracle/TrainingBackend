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
        public int Id { get; set; }
        public string? Name { get; set; }
        //public int? CompanyInfoKey { get; set; }
        //[ForeignKey("CompanyInfoKey")] Аннотация для внешнего ключа
        public string? CompanyName { get; set; }
        public Company? Company { get; set; }
    }
}
