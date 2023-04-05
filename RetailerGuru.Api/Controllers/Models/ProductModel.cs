namespace RetailerGuru.Api.Controllers.Models
{
    public class ProductModel
    {
        public int Id { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public Guid CompanyId { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; } = 0;
    }
}
