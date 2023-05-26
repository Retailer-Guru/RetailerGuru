using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;

namespace RetailerGuru.Core.Queries.Products
{
    public static class GetProducts
    {
        public class Query : IQuery<Result> { }

        public class Result
        {
            public List<Item> Items { get; set; } = new List<Item>();

            public class Item
            {
                public int Id { get; set; }
                public Guid CompanyId { get; set; }
                public string Name { get; set; } = string.Empty;
                public decimal Price { get; set; }
                public int StockAmound { get; set; }
            }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override async Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Result
                {
                    Items = await _context.Set<Product>()
                    .Select(x => new Result.Item
                    {
                        Id = x.Id,
                        CompanyId = x.CompanyId,
                        Name = x.Name,
                        Price = x.Price,
                        StockAmound = x.StockAmount
                    }).ToListAsync()
                };
            }
        }
    }
}
