namespace RetailerGuru.Core.Extensions
{
    public interface ICoreConfigurationBuilder
    {
        bool UseInMemoryDBContext { get; set; }
        string ConnectionString { get; set; }
    }

    public class CoreConfigurationBuilder : ICoreConfigurationBuilder
    {
        public bool UseInMemoryDBContext { get; set; }
        public string ConnectionString { get; set; } = string.Empty;
    }
}
