using RetailerGuru.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Data.Models
{
    // TODO: Idee von Herr Felder austesten (Youtube style Guid)
    public record class Company : BaseEntity<Guid>
    {
        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [MaxLength(9)]
        public string ATU { get; set; }
    }
}
