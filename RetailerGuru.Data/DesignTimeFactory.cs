using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RetailerGuru.Data
{
    public class DesignTimeFactory : IDesignTimeDbContextFactory<RetailerGuruContext>
    {
        public RetailerGuruContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RetailerGuruContext>();

            // TODO: Replace with actual connection
            /*optionsBuilder.UseMySql(@"Server=192.168.0.2;Database=BillCreator;Uid=BillCreatorUser;Pwd=4N0eCdTqkAk998gibtVu#", 
                ServerVersion.AutoDetect(@"Server=192.168.0.2;Database=BillCreator;Uid=BillCreatorUser;Pwd=4N0eCdTqkAk998gibtVu#"));*/

            return new RetailerGuruContext(optionsBuilder.Options);
        }
    }
}
