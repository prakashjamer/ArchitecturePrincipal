using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Entities
{
    public class Biography: BaseProperties
    {
        [Key]
        public int  Id { get; set; }
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; }
        [ForeignKey("ActorId")]
        public Actor? Actor { get; set; }    
        public int ActorId { get; set; }

    }
}
