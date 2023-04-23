using Microsoft.EntityFrameworkCore;
using RetailerGuru.Data.Models;
using RetailerGuru.Data.Models.Base;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Security.Cryptography;

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

        // TODO: vll obus anschauen
        private void Seed()
        {
            if (_isSeeded || !Database.IsInMemory())
                return;

            _isSeeded = true;

            var company = new Company
            {
                Name = "TestCompany",
                ATU = "123456789"
            };

            Add(company);

            SaveChanges();

            Add(new Product
            {
                CompanyId = company.Id,
                Price = (decimal)1.123,
                Name = "Product1",
                StockAmount = 100,
            });

            Add(new Product
            {
                CompanyId = company.Id,
                Price = (decimal)2.123,
                Name = "Product2",
                StockAmount = 50,
            });

            Add(new Product
            {
                CompanyId = company.Id,
                Price = (decimal)3.123,
                Name = "Product3",
                StockAmount = 50,
            });

            using var sha = SHA256.Create();
            Add(new User
            {
                CompanyId = company.Id,
                Username = "test",
                Password = Encoding.UTF8.GetString(sha.ComputeHash(Encoding.UTF8.GetBytes("test")))
            });

            SaveChanges();
        }
    }
}
