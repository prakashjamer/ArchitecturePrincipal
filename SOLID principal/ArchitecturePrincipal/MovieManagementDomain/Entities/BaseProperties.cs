using System.ComponentModel.DataAnnotations;

namespace MovieManagementDomain.Entities
{
    public class BaseProperties
    {
        [MinLength(1)]
        [MaxLength(500)]
        public string CreatedBy { get; set; } = "API";
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime ModifiedDate { get; set; } = DateTime.UtcNow;
        [MinLength(1)]
        [MaxLength(500)]
        public string ModifiedBy { get; set; } = "API";

    }
}