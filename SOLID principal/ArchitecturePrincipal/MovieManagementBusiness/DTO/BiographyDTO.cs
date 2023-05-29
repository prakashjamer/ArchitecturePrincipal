using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementBusiness.DTO
{
    public class BiographyDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ActorDTO? Actor { get; set; }
        public int ?ActorId { get; set; }
    }
}
