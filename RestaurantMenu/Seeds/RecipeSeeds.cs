using System;
using RestaurantMenu.DAL.Entities;
using RestaurantMenu.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace RestaurantMenu.DAL.Seeds
{
    public static class RecipeSeeds
    {
        public static readonly RecipeEntity LemonadeRecipe = new(
            Id: Guid.NewGuid(),
            Name: "Lemonade",
            Description: "Sweet-sour summer lemonade",
            Duration: TimeSpan.FromMinutes(value: 1.2),
            FoodType: FoodType.Drink,
            ImageUrl: @"https://images-gmi-pmc.edge-generalmills.com/2586d951-a46a-4091-aec6-eca3adefb409.jpg"
            );

        static RecipeSeeds()
        {
            // Implement ingredientamountseeds
            LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeLemon);
            LemonadeRecipe.Ingredients.Add(IngredientAmountSeeds.LemonadeWater);
        }


        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecipeEntity>().HasData(
                LemonadeRecipe with { Ingredients = Array.Empty<IngredientAmountEntity>() }
            );
        }
    }
}
