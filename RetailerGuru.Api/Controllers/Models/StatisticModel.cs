namespace RetailerGuru.Api.Controllers.Models
{
    public class StatisticModel<T>
    {
        public T Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
