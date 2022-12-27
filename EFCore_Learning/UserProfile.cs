using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    //[Owned] // Через аннотацию
    public class UserProfile
    {
        public Claim? Name { get; set; }
        public Claim? Age { get; set; }
    }
}
