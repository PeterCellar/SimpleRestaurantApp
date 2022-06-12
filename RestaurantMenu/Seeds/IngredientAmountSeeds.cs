using System;
using RestaurantMenu.Common.Enums;
using RestaurantMenu.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace RestaurantMenu.DAL.Seeds
{
    public static class IngredientAmountSeeds
    {
        public static readonly IngredientAmountEntity LemonadeLemon = new(
            Id: Guid.NewGuid(),
            Amount: 250,
            Unit: Unit.G,
            RecipeId: RecipeSeeds.LemonadeRecipe.Id,
            IngredientId: IngredientSeeds.Lemon.Id
            );

        public static readonly IngredientAmountEntity LemonadeWater = new(
            Id: Guid.NewGuid(),
            Amount: 2.0,
            Unit: Unit.L,
            RecipeId: RecipeSeeds.LemonadeRecipe.Id,
            IngredientId: IngredientSeeds.Water.Id
            );

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientAmountEntity>().HasData(
                LemonadeLemon with { Recipe = null, Ingredient = null },
                LemonadeWater with { Recipe = null, Ingredient = null }
                );
        }
    }
}
