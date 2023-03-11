using RetailerGuru.Api.Infrastructure;
using RetailerGuru.Api.Infrastructure.Versions;
using Microsoft.AspNetCore.Mvc;
using RetailerGuru.Data.Models;

namespace RetailerGuru.Api.Controllers.Private
{
    [SpaApiV1]
    public class ProductController : ApiController
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                CompanyId = Guid.NewGuid(),
                Price = (decimal)1.123,
                Name = "Product1",
                StockAmount = 100,
            },
            new Product
            {
                Id = 2,
                CompanyId = Guid.NewGuid(),
                Price = (decimal)2.123,
                Name = "Product2",
                StockAmount = 50,
            },
            new Product
            {
                Id = 3,
                CompanyId = Guid.NewGuid(),
                Price = (decimal)3.123,
                Name = "Product3",
                StockAmount = 50,
            },
        };

        [HttpGet("GetProduct/{id}")]
        public Product? GetProduct(int id)
        {
            return _products.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("GetProdcuts")]
        public List<Product> GetProducts()
        {
            return _products;
        }
    }
}
