using RetailerGuru.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Data.Models
{
    // TODO: email hinzufügen
    public record class User : BaseEntity<Guid>
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Username { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string Password { get; set; }

        [Required]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
    }
}
