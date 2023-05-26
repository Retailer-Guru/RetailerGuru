using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Queries.Statistics
{
    public static class GetDailyProductSearch
    {
        public class Query : IQuery<Result>
        {
            [Required]
            public int ProductId { get; set; }

            [Required]
            public DateTime From { get; set; }

            [Required]
            public DateTime To { get; set; }
        }

        public class Result
        {
            public List<Item> Items { get; set; } = new List<Item>(); 

            public class Item
            {
                public DateTime Date { get; set; }
                public int Count { get; set; }
            }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context)
            {
            }

            public override async Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Set<Product>().FirstOrDefaultAsync(x => x.Id == request.ProductId);

                if (product is null)
                    return null;

                return new Result
                {
                    Items = await _context.Set<ProductSearch>()
                    .Where(x => x.ProductId == request.ProductId 
                        && x.Date.Date >= request.From.Date 
                        && x.Date.Date <= request.To.Date)
                    .GroupBy(x => new { x.Date.Date})
                    .Select(x => new Result.Item
                    {
                        Date = x.Key.Date,
                        Count = x.Count()
                    }).ToListAsync()
                };
            }
        }
    }
}
