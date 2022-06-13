using Microsoft.EntityFrameworkCore;
using RestaurantMenu.Common.Enums;
using RestaurantMenu.DAL.Entities;

namespace RestaurantMenu.Common.Tests.Seeds
{
    public static class IngredientAmountSeeds
    {
        public static readonly IngredientAmountEntity EmptyIngredientAmountEntity = new(
            Id: default,
            Amount: default,
            Unit: default,
            RecipeId: default,
            IngredientId: default);

        public static readonly IngredientAmountEntity IngredientAmount1 = new(
            Id: Guid.NewGuid(),
            Amount: 25.0,
            Unit: Unit.G,
            RecipeId: RecipeSeeds.RecipeEntity.Id,
            IngredientId: IngredientSeeds.IngredientEntity1.Id)
        {
            Recipe = RecipeSeeds.RecipeEntity,
            Ingredient = IngredientSeeds.IngredientEntity1
        };

        public static readonly IngredientAmountEntity IngredientAmount2 = new(
            Id: Guid.NewGuid(),
            Amount: 1.0,
            Unit: Unit.L,
            RecipeId: RecipeSeeds.RecipeEntity.Id,
            IngredientId: IngredientSeeds.IngredientEntity2.Id)
        {
            Recipe = RecipeSeeds.RecipeEntity,
            Ingredient = IngredientSeeds.IngredientEntity2
        };


        //To ensure that no tests reuse these clones for non-idempotent operations
        public static readonly IngredientAmountEntity IngredientAmountEntityUpdate = IngredientAmount1 with { Id = Guid.Parse("A2E6849D-A158-4436-980C-7FC26B60C674"), Ingredient = null, Recipe = null, RecipeId = RecipeSeeds.RecipeForIngredientAmountEntityUpdate.Id };
        public static readonly IngredientAmountEntity IngredientAmountEntityDelete = IngredientAmount1 with { Id = Guid.Parse("30872EFF-CED4-4F2B-89DB-0EE83A74D279"), Ingredient = null, Recipe = null, RecipeId = RecipeSeeds.RecipeForIngredientAmountEntityDelete.Id };

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientAmountEntity>().HasData(
                IngredientAmount1 with { Recipe = null, Ingredient = null},
                IngredientAmount2 with { Recipe = null, Ingredient = null},
                IngredientAmountEntityUpdate,
                IngredientAmountEntityDelete);
        }

    }
}
