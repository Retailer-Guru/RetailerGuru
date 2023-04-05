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

namespace RetailerGuru.Core.Queries.Products
{
    public static class GetProductById
    {
        public class Query : IQuery<Result>
        {
            [Required]
            public int Id { get; set; }
        }

        public class Result
        {
            public int Id { get; set; }
            public Guid CompanyId { get; set; }
            public string Name { get; set; } = string.Empty;
            public decimal Price { get; set; }
            public int StockAmound { get; set; }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Set<Product>()
                    .Select(x => new Result
                    {
                        Id = x.Id,
                        CompanyId = x.CompanyId,
                        Name = x.Name,
                        Price = x.Price,
                        StockAmound = x.StockAmount
                    })
                    .FirstOrDefaultAsync(x => x.Id == request.Id);
            }
        }
    }
}
