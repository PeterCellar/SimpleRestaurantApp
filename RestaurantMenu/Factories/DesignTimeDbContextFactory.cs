using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantMenu.DAL.Factories
{
    // Interface documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-6.0
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RestaurantMenuDbContext>
    {
        public RestaurantMenuDbContext CreateDbContext(string[] args)
        {
            // OptionsBuilder documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder?view=efcore-6.0
            DbContextOptionsBuilder<RestaurantMenuDbContext> optionsBuilder = new();

            // UseSqlServer documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.sqlserverdbcontextoptionsextensions.usesqlserver?view=efcore-6.0#microsoft-entityframeworkcore-sqlserverdbcontextoptionsextensions-usesqlserver(microsoft-entityframeworkcore-dbcontextoptionsbuilder-system-action((microsoft-entityframeworkcore-infrastructure-sqlserverdbcontextoptionsbuilder)))
            optionsBuilder.UseSqlServer(
                @"Data Source=(LocalDB)\MSSQLLocalDB;
                Initial Catalog = CookBook;
                MultipleActiveResultSets = True;
                Integrated Security = True; "
                );

            return new RestaurantMenuDbContext(optionsBuilder.Options);
        }
    }
}
