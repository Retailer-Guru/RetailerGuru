using MediatR;

namespace RetailerGuru.Core.Infrastructure
{
    public interface ICommand : ICommand<Unit> { }
    public interface ICommand<TResponse> : IRequest<TResponse> { }
}
