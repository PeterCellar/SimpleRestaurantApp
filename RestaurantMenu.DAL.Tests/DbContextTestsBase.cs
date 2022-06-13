using System;
using System.Threading.Tasks;
using RestaurantMenu.DAL.Factories;
using Xunit.Abstractions;
using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Common.Tests;
using RestaurantMenu.Common.Tests.Factories;

namespace RestaurantMenu.DAL.Tests
{
    public class DbContextTestsBase : IAsyncLifetime
    {
        // Constructor
        protected DbContextTestsBase(ITestOutputHelper outputHelper)
        {
            XUnitTestOutputConverter converter = new(outputHelper);
            Console.SetOut(converter);

            DbContextFactory = new DbContextSQLiteTestingFactory(GetType().FullName!, seedTestingData: true);

            RestaurantMenuDbContextSUT = DbContextFactory.CreateDbContext();
        }

        protected IDbContextFactory<RestaurantMenuDbContext> DbContextFactory { get; }
        protected RestaurantMenuDbContext RestaurantMenuDbContextSUT { get; }

        public async Task InitializeAsync()
        {
            await RestaurantMenuDbContextSUT.Database.EnsureDeletedAsync();
            await RestaurantMenuDbContextSUT.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await RestaurantMenuDbContextSUT.Database.EnsureDeletedAsync();
            await RestaurantMenuDbContextSUT.DisposeAsync();
        }

    }
}
