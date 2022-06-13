using RestaurantMenu.DAL;
using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Common.Tests.Seeds;

namespace RestaurantMenu.Common.Tests
{
    internal class RestaurantMenuTestingDbContext : RestaurantMenuDbContext
    {
        private readonly bool _seedTestingData;

        public RestaurantMenuTestingDbContext(DbContextOptions contextOptions, bool seedTestingData = false) 
            : base(contextOptions, seedDemoData:false)
        {
            _seedTestingData = seedTestingData;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            if (_seedTestingData)
            {
                // Seeding data
                IngredientSeeds.Seed(modelBuilder);
                RecipeSeeds.Seed(modelBuilder);
                IngredientAmountSeeds.Seed(modelBuilder);
            }
        }
    }
}
