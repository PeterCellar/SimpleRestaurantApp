

using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL;

namespace RestaurantMenu.Common.Tests.Factories
{
    public class DbContextTestingInMemortFactory : IDbContextFactory<RestaurantMenuDbContext>
    {
        private readonly string _databaseName;
        private readonly bool _seedTestingData;

        public DbContextTestingInMemortFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }

        public RestaurantMenuDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<RestaurantMenuDbContext> contextOptionsBuilder = new();
            contextOptionsBuilder.UseInMemoryDatabase(_databaseName);

            return new RestaurantMenuTestingDbContext(contextOptionsBuilder.Options, _seedTestingData);
        }
    }
}
