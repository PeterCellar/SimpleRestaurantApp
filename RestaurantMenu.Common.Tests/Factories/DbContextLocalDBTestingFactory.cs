using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL;

namespace RestaurantMenu.Common.Tests.Factories
{
    public class DbContextLocalDBTestingFactory : IDbContextFactory<RestaurantMenuDbContext>
    {
        private readonly string _databaseName;
        private readonly bool _seedTestingData;

        // Constructor
        public DbContextLocalDBTestingFactory(string databaseName, bool seedTestingData = false)
        {
            _databaseName = databaseName;
            _seedTestingData = seedTestingData;
        }

        public RestaurantMenuDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<RestaurantMenuDbContext> builder = new();
            builder.UseSqlServer($"Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = {_databaseName};MultipleActiveResultSets = True;Integrated Security = True; ");

            return new RestaurantMenuTestingDbContext(builder.Options, _seedTestingData);
        }
    }
}
