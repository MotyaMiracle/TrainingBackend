using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Learning
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CapitalId { get; set; }
        public City? Capital { get; set; } // Столица страны
        public List<Company> Companies { get; set; } = new();
    }
}
