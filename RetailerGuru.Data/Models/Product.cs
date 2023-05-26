using Microsoft.EntityFrameworkCore;
using RetailerGuru.Data.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Data.Models
{
    public record class Product : IdEntity
    {
        [Required]
        public Company Company { get; set; }
        public Guid CompanyId { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Precision(18, 3)]
        public decimal Price { get; set; }

        [Required]
        public int StockAmount { get; set; }
    }
}
