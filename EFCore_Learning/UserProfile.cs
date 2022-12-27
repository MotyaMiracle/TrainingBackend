using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        
        //public int UserKey { get; set; }
        public User? User { get; set; }
    }
}
