using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class Course
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Student> Students { get; set; } = new();
        public List<Enrollments> Enrollments { get; set; } = new();
    }
}
