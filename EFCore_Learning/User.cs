using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        // Если поставить int? то будет допускать значеине null что человек может быть без компании, тоже самое будет если убрать CompanyId
        //public int CompanyId { get; set; } 
        public Company? Company { get; set; }
    }
}
