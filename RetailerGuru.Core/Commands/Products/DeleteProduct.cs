using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Commands.Products
{
    public static class DeleteProduct
    {
        public class Command : ICommand
        {
            [Required]
            public int Id { get; set; }
        }

        internal class Handler : ContextRequestHandler<Command>
        {
            public Handler(RetailerGuruContext context) : base(context)
            {
            }

            public override async Task HandleDefaultCommand(Command request, CancellationToken cancellationToken)
            {
                var product = await _context.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.Id);

                if (product is null)
                    return;

                _context.Remove(product);

                await _context.SaveChangesAsync();
            }
        }
    }
}
