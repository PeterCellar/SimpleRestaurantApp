using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL;


namespace RestaurantMenu.Common.Tests.Factories
{
    public class DbContextSQLiteTestingFactory : IDbContextFactory<RestaurantMenuDbContext>
    {
        private readonly string _databaseName;
        private readonly bool _seedTestingData;

        public DbContextSQLiteTestingFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }

        public RestaurantMenuDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<RestaurantMenuDbContext> builder = new();
            builder.UseSqlite($"Data Source={_databaseName};Cache=Shared");

            return new RestaurantMenuTestingDbContext(builder.Options, _seedTestingData);
        }
    }
}
