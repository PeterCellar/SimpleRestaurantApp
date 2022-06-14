using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace RestaurantMenu.DAL.Factories
{
    // !! EF Core CLI migration generation should use this DbContext to create model and migration

    // Interface documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.design.idesigntimedbcontextfactory-1?view=efcore-6.0
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RestaurantMenuDbContext>
    {
        /* 
         * This factory method is a creational design pattern which solves the problem of creating
         * DbContext. (Factory method generally: solves problem of creating product objects 
         * without specifying their concrete class)
        */
        public RestaurantMenuDbContext CreateDbContext(string[] args)
        {
            // OptionsBuilder documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptionsbuilder?view=efcore-6.0
            /* 
             * Provides API surface for configuring DbContextOptions. Databases define extension
             * methods on this object that allow to configure the database connection to be used 
             * for a context. 
             */
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
