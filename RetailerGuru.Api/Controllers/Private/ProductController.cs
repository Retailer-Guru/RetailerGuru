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
                CompanyId = new Guid("1"),
                Price = (decimal)1.123,
                StockAmount = 100,
            },
            new Product
            {
                Id = 2,
                CompanyId = new Guid("1"),
                Price = (decimal)2.123,
                StockAmount = 50,
            },
            new Product
            {
                Id = 3,
                CompanyId = new Guid("2"),
                Price = (decimal)3.123,
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
