using System;
using System.Collections.Generic;
using Nemesis.Essentials.Design;
using RestaurantMenu.Common.Enums;

namespace RestaurantMenu.DAL.Entities
{
    // Represents recipe used to make a dish/drink in restaurant
    public record RecipeEntity(
        Guid Id,
        string Name,
        string Description,
        TimeSpan Duration,
        FoodType FoodType,
        string? ImageUrl) : IEntity
    {
        // All ingredients used in recipe
        // Iterable -> we can add new ingredients
        public ICollection<IngredientAmountEntity> Ingredients { get; init; } = new List<IngredientAmountEntity>();
    }
}
