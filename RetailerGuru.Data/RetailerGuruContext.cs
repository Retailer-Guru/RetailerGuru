using Microsoft.EntityFrameworkCore;
using RetailerGuru.Data.Models;
using RetailerGuru.Data.Models.Base;

namespace RetailerGuru.Data
{
    public class RetailerGuruContext : DbContext
    {
        private static bool _isSeeded = false;

        public RetailerGuruContext(DbContextOptions options) : base(options)
        {
            if(!_isSeeded)
                Seed();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Loading the types and adding them to the context
            foreach (var type in typeof(IEntity).Assembly.GetExportedTypes()
                                            .Where(x => typeof(IEntity).IsAssignableFrom(x)))
                if (!type.IsAbstract && !type.IsInterface && type.IsClass)
                    modelBuilder.Entity(type);

            var relation = modelBuilder.Model.GetEntityTypes().SelectMany(c => c.GetForeignKeys());
            foreach (var item in relation)
                item.DeleteBehavior = DeleteBehavior.Restrict;
        }

        private void Seed()
        {
            if (_isSeeded || !Database.IsInMemory())
                return;

            _isSeeded = true;

            Add(new Product
            {
                CompanyId = Guid.NewGuid(),
                Price = (decimal)1.123,
                Name = "Product1",
                StockAmount = 100,
            });

            Add(new Product
            {
                CompanyId = Guid.NewGuid(),
                Price = (decimal)2.123,
                Name = "Product2",
                StockAmount = 50,
            });

            Add(new Product
            {
                CompanyId = Guid.NewGuid(),
                Price = (decimal)3.123,
                Name = "Product3",
                StockAmount = 50,
            });

            SaveChanges();
        }
    }
}
