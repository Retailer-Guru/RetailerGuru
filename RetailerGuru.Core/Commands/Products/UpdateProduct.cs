using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailerGuru.Core.Commands.Products
{
    public static class UpdateProduct
    {
        public class Command : ICommand
        {
            [Required]
            public int Id { get; set; }

            [Required]
            public Guid CompanyId { get; set; }

            [Required]
            [StringLength(150, MinimumLength = 2)]
            public string Name { get; set; } = string.Empty;

            [Required]
            [Precision(18, 3)]
            public decimal Price { get; set; }

            [Required]
            public int StockAmount { get; set; }
        }

        internal class Handler : ContextRequestHandler<Command>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override async Task HandleDefaultCommand(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (product is null)
                    return;

                product.Name = request.Name;
                product.Price = request.Price;
                product.StockAmount = request.StockAmount;

                await _context.SaveChangesAsync();
            }
        }
    }
}
