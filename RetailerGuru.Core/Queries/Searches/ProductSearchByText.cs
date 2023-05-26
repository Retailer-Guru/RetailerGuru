using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Queries.Searches
{
    public static class ProductSearchByText
    {
        public class Query : IQuery<Result>
        {
            [Required]
            public string SearchText { get; set; } = string.Empty;
        }

        public class Result
        {
            public List<Item> Items { get; set; } = new List<Item>();

            public class Item
            {
                public int ProdcutId { get; set; }
                public string Name { get; set; } = string.Empty;
                public decimal Price { get; set; }
            }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override async Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(request.SearchText) || string.IsNullOrWhiteSpace(request.SearchText))
                    return null;

                if (_context.IsInMemory)
                {
                    return new Result
                    {
                        // Contains only works in an InMemoryDb and there is no other fulltext search implemeted for it
                        // ToLower is needed becaus a InMemoryDb is case sensetive
                        Items = await _context.Set<Product>()
                        .Where(x => x.Name.ToLower().Contains(request.SearchText.ToLower())
                            || request.SearchText.ToLower().Contains(x.Name.ToLower()))
                        .Select(x => new Result.Item
                        {
                            ProdcutId = x.Id,
                            Name = x.Name,
                            Price = x.Price,
                        }).ToListAsync()
                    }; 
                }
                else
                {
                    // TODO: Implement Query for LiveDB
                    throw new NotImplementedException();
                }
            }
        }
    }
}
