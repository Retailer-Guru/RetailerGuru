using MediatR;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Api.Controllers.Models;
using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using RetailerGuru.Core.Commands.Products;
using RetailerGuru.Core.Queries.Products;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class ProductController : ApiController
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetProduct/{id}")]
        public Task<GetProductById.Result> GetProduct(int id)
        {
            return _mediator.Send(new GetProductById.Query { Id = id });
        }

        [HttpGet("GetProdcuts")]
        public Task<GetProducts.Result> GetProducts()
        {
            return _mediator.Send(new GetProducts.Query());
        }

        [HttpPost("AddProduct")]
        public void AddProduct([FromBody] ProductModel model)
        {
            _mediator.Send(new InstertProduct.Command
            {
                Id = model.Id,
                Name = model.Name,
                CompanyId = model.CompanyId,
                Price = model.Price,
                StockAmount = model.StockAmount,
            });
        }

        [HttpPost("UpdateProduct")]
        public void UpdateProduct([FromBody] ProductModel model)
        {
            _mediator.Send(new UpdateProduct.Command
            {
                Id = model.Id,
                Name = model.Name,
                CompanyId = model.CompanyId,
                Price = model.Price,
                StockAmount = model.StockAmount,
            });
        }

        [HttpDelete("DeleteProduct/{id}")]
        public void DeleteProduct(int id)
        {
            _mediator.Send(new DeleteProduct.Command { Id = id });
        }
    }
}
