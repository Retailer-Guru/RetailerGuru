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

        public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
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
