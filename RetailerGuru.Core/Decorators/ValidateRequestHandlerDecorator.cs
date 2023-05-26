using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RetailerGuru.Core.Decorators
{
    public class ValidationRequestHandlerDecorator<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IRequestHandler<TRequest, TResponse> _innerQueryHandler;

        public ValidationRequestHandlerDecorator(IRequestHandler<TRequest, TResponse> innerQueryHandler) => _innerQueryHandler = innerQueryHandler;

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            Validator.ValidateObject(request, new ValidationContext(request));
            return _innerQueryHandler.Handle((dynamic)request, cancellationToken);
        }
    }
}
