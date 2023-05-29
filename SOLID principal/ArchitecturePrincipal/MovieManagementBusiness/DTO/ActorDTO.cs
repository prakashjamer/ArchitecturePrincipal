using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBusiness.DTO
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public List<MovieDTO>? Movies { get; set; }
        public BiographyDTO? Biography { get; set; }
    }
}
