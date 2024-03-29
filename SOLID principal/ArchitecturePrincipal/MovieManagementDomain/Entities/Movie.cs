﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagementDomain.Entities
{
    public class Movie: BaseProperties
    {
        [Key]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(150)]
        public string Name { get; set; } = string.Empty;
        [MinLength(1)]
        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Actor> Actors { get; set; }



    }
}
