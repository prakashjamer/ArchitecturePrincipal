using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Entities
{
    public class Actor
    {
        public int Id {get; set;}
        public string Name {get; set;} = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<Movie>? Movies { get; set; }
        public Biography? Biography { get; set; }
    }
}
