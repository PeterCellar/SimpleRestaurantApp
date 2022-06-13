using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Common.Enums;
using RestaurantMenu.Common.Tests;
using RestaurantMenu.Common.Tests.Seeds;
using RestaurantMenu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace RestaurantMenu.DAL.Tests
{
    public class DbContextRecipeTests : DbContextTestsBase
    {
        public DbContextRecipeTests(ITestOutputHelper outputHelper) : base(outputHelper)
        {
        }

        [Fact]
        public async Task AddNew_RecipeWithoutIngredients_Persisted()
        {
            // Creating new recipe
            var recipe = RecipeSeeds.EmptyRecipe with
            {
                Name = "Chicken soup",
                Description = "Delicous soup made of chickens from Ireland"
            };

            // Adding new recipe
            RestaurantMenuDbContextSUT.Recipes.Add(recipe);
            await RestaurantMenuDbContextSUT.SaveChangesAsync();

            // Asserting equality
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var recipeEntity = await dbx.Recipes.SingleAsync(i => i.Id == recipe.Id);
            DeepAssert.Equal(recipe, recipeEntity);
        }


        // Adding ingredients alongside a recipe
        // Bad dsign -> ingredients are strong entities
        [Fact]
        public async Task AddNew_RecipeWithIngredients_Persisted()
        {
             
            // Creating new recipe with ingredients
            var entity = RecipeSeeds.EmptyRecipe with
            {
                Name = "Lemonda",
                Description = "Fresh summer beverage", 
                Ingredients = new List<IngredientAmountEntity>
                {
                    IngredientAmountSeeds.EmptyIngredientAmountEntity with
                    {
                        Amount = 2,
                        Unit = Unit.L,
                        Ingredient = IngredientSeeds.EmptyIngredient with
                        {
                            Name = "Water",
                            Description = "Pure water",
                            ImageUrl = "https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
                        }
                    },
                    IngredientAmountSeeds.EmptyIngredientAmountEntity with
                    {
                        Amount = 120,
                        Unit = Unit.G,
                        Ingredient = IngredientSeeds.EmptyIngredient with
                        {
                            Name = "Lemon",
                            Description = "Spanish lemons",
                            ImageUrl = null
                        }
                    }
                }

            };

            // Adding new recipe
            RestaurantMenuDbContextSUT.Recipes.Add(entity);
            await RestaurantMenuDbContextSUT.SaveChangesAsync();

            // Asserting equality
            await using var dbx = await DbContextFactory.CreateDbContextAsync();
            var actualEntity = await dbx.Recipes
                .Include(i => i.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .SingleAsync(i => i.Id == entity.Id);
            DeepAssert.Equal(entity, actualEntity);
        }
    }
}
