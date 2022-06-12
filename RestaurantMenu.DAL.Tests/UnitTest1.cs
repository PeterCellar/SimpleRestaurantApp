using Microsoft.EntityFrameworkCore;

// NugetPackage: EntityFrameworkCore.InMemory
namespace RestaurantMenu.DAL.Tests
{
    public class DbContextIngredientTests
    {
        private readonly RestaurantMenuDbContext _restaurantMenuDbContextSUT;

        //private readonly RestaurantMenuDbContext restaurantMenuDbContextSUT;

        public DbContextIngredientTests()
        {
            // SUT -> System Under Test
            var dbContextOptions = new DbContextOptionsBuilder<RestaurantMenuDbContext>();
            dbContextOptions.UseInMemoryDatabase("RestaurantMenu");
            _restaurantMenuDbContextSUT = new RestaurantMenuDbContext(dbContextOptions.Options, true);
            _restaurantMenuDbContextSUT.Database.EnsureCreated();
        }

         

        [Fact]
        public void GetAllIngredients()
        {
            var Ingredients
                = _restaurantMenuDbContextSUT.Ingredients.ToArray();

            Assert.True(Ingredients.Any());
        }
    }
}