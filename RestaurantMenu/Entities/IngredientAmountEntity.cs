using RestaurantMenu.Common.Enums;
using System;
using System.Collections.Generic;

// Records documentation: https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/records
namespace RestaurantMenu.DAL.Entities
{
    // Ingredient amount used in recipe
    public record IngredientAmountEntity(
        Guid Id,
        double Amount,
        Unit Unit,
        Guid RecipeId,
        Guid IngredientId) : IEntity
    {
#nullable disable
        public IngredientAmountEntity() : this(default, default, default, default, default) { }
#nullable enable
        // Navigational properties
        // Through SQL JOINS possible to access db items
        public RecipeEntity? Recipe { get; init; }
        public IngredientEntity? Ingredient { get; init; }
    }
}
