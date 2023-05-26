using RetailerGuru.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Data.Models
{
    public record class VerifiedSale : IdEntity
    {
        [Required]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }
    }
}
