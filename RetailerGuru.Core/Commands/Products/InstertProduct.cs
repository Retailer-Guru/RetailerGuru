using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Commands.Products
{
    public static class InstertProduct
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
                var company = await _context.Set<Company>().FirstOrDefaultAsync(x => x.Id == request.CompanyId);

                if (company is null)
                    return;

                _context.Add(new Product
                {
                    CompanyId = company.Id,
                    Name = request.Name,
                    Price = request.Price,
                    StockAmount = request.StockAmount,
                });

                await _context.SaveChangesAsync();
            }
        }
    }
}
