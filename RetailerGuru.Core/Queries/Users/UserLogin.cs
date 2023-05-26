using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Extensions;
using RetailerGuru.Core.Infrastructure;
using RetailerGuru.Core.Infrastructure.Foundation;
using RetailerGuru.Data;
using RetailerGuru.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Queries.Users
{
    public static class UserLogin
    {
        public class Query : IQuery<Result>
        {
            [Required]
            [StringLength(100, MinimumLength = 2)]
            public string Username { get; set; } = string.Empty;

            [Required]
            [StringLength(100, MinimumLength = 2)]
            public string Password { get; set; } = string.Empty;
        }

        public class Result
        {
            public Guid UserId { get; set; }
            public Guid CompanyId { get; set; }
        }

        internal class Handler : ContextRequestHandler<Query, Result>
        {
            public Handler(RetailerGuruContext context) : base(context) { }

            public override Task<Result?> Handle(Query request, CancellationToken cancellationToken)
            {
                return _context.Set<User>()
                    .Where(x => x.Username == request.Username && x.Password == request.Password.Encrypt())
                    .Select(x => new Result
                    {
                        UserId = x.Id,
                        CompanyId = x.CompanyId
                    }).FirstOrDefaultAsync();
            }
        }
    }
}
