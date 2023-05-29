using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Entities
{
    public class Actor: BaseProperties
    {
        [Key]
        public int Id {get; set;}
        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Name {get; set;} = string.Empty;
        [MinLength(1)]
        [MaxLength(150)]
        public string LastName { get; set; } = string.Empty;
        public Biography? Biography { get; set; }
        public ICollection<Movie> Movies { get; set; }
        
    }
}
