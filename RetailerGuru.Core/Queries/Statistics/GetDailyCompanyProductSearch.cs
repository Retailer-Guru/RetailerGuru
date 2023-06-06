using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Queries.Statistics
{
    public static class GetDailyCompanyProductSearch
    {
        public class Query : IQuery<Result>
        {
            [Required]
            public Guid CompanyId { get; set; }

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
                public int Count { get; set; }
                public DateTime Date { get; set; }
            }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override async Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                return new Result
                {
                    Items = await _context.Set<ProductSearch>()
                        .Where(x => x.Product.CompanyId == request.CompanyId
                            && x.Date.Date >= request.From.Date
                            && x.Date.Date <= request.To.Date)
                        .GroupBy(x => new { x.Date.Year, x.Date.Month, x.Date.Day })
                        .Select(x => new Result.Item
                        {
                            Date = new DateTime().AddYears(x.Key.Year).AddMonths(x.Key.Month).AddDays(x.Key.Day),
                            Count = x.Count()
                        }).ToListAsync()
                };
            }
        }
    }
}
