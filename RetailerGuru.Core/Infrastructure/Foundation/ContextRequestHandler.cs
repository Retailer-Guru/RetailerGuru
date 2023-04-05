using RetailerGuru.Data;
using MediatR;

namespace RetailerGuru.Core.Infrastructure.Foundation
{
    public abstract class ContextRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        protected readonly RetailerGuruContext _context;

        public ContextRequestHandler(RetailerGuruContext context)
        {
            _context = context;
        }

#pragma warning disable CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
        public abstract Task<TResponse?> Handle(TRequest request, CancellationToken cancellationToken);
#pragma warning restore CS8613 // Nullability of reference types in return type doesn't match implicitly implemented member.
    }

    public abstract class ContextRequestHandler<TRequest> : ContextRequestHandler<TRequest, Unit>
        where TRequest : ICommand<Unit>
    {
        public ContextRequestHandler(RetailerGuruContext context) : base(context) { }

        public override async Task<Unit> Handle(TRequest request, CancellationToken cancellationToken)
        {
            await HandleDefaultCommand(request, cancellationToken);
            return new Unit();
        }

        public abstract Task HandleDefaultCommand(TRequest request, CancellationToken cancellationToken);
    }
}
