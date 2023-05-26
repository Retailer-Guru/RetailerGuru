using MediatR;

namespace RetailerGuru.Core.Infrastructure
{
    public interface IQuery<TResponse> : IRequest<TResponse> { }
}
