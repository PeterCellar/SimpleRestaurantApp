using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL.Entities;
using RestaurantMenu.DAL.Seeds;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantMenu.DAL
{
    // DbContext documentation: https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext?view=entity-framework-6.2.0
    public class RestaurantMenuDbContext : DbContext
    {
        private readonly bool _seedDemoData;

        // DbContextOptions documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontextoptions?view=efcore-6.0
        public RestaurantMenuDbContext(DbContextOptions contextOptions, bool seedDemoData = false)
            : base(contextOptions)
        {
            _seedDemoData = seedDemoData;
        }

        // DbSet documentation: https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset-1?view=entity-framework-6.2.0

        // Opens access to recipe table
        public DbSet<RecipeEntity> Recipes => Set<RecipeEntity>();
        // Opens access to ingredient table
        public DbSet<IngredientEntity> Ingredients => Set<IngredientEntity>();
        // Opens access to ingredientamount table
        public DbSet<IngredientAmountEntity> IngredientAmounts => Set<IngredientAmountEntity>();

        // OnModelCrating documentation: https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext.onmodelcreating?view=entity-framework-6.2.0
        // Seeds data to database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeEntity>()
                .HasMany(e => e.Ingredients)
                .WithOne(e => e.Recipe)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<IngredientEntity>()
                .HasMany<IngredientAmountEntity>()
                .WithOne(e => e.Ingredient)
                .OnDelete(DeleteBehavior.Cascade);

            if (_seedDemoData)
            {
                IngredientAmountSeeds.Seed(modelBuilder);
                RecipeSeeds.Seed(modelBuilder);
                IngredientSeeds.Seed(modelBuilder);
            }
        }
    }
}
