using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;

namespace RetailerGuru.Core.Queries.Companyies
{
    public static class GetFirstCompanyId
    {
        public class Query : IQuery<Guid>
        {
        }

        internal class Handler : ContextRequestHandler<Query, Guid>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override async Task<Guid> Handle(Query request, CancellationToken cancellationToken)
            {
                return (await _context.Set<Company>()
                    .FirstAsync())
                    .Id;
            }
        }
    }
}
