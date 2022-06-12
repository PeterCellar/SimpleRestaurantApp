using Microsoft.EntityFrameworkCore;

namespace RestaurantMenu.DAL.Factories
{
    // Interface documentation: https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.infrastructure.idbcontextfactory-1?view=entity-framework-6.2.0
    public class SqlServerDbContextFactory : IDbContextFactory<RestaurantMenuDbContext>
    {
        private readonly string _connectionString;
        private readonly bool _seedDemoData;

        // Constructor
        public SqlServerDbContextFactory(string connectionString, bool seedDemoData = false)
        {
            _connectionString = connectionString;
            _seedDemoData = seedDemoData;
        }

        public RestaurantMenuDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RestaurantMenuDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);

            return new RestaurantMenuDbContext(optionsBuilder.Options, _seedDemoData);
        }
        
    }
}
