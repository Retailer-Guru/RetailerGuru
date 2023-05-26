using RetailerGuru.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Data.Models
{
    public record class ProductSearch : IdEntity
    {
        [Required]
        public Product Product { get; set; }
        public int ProductId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 7)]
        public string IpAdress { get; set; }
    }
}
