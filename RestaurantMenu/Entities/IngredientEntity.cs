using System;

namespace RestaurantMenu.DAL.Entities
{
    // Represents Ingredient used in recipe
    public record IngredientEntity(
        Guid Id,
        string Name,
        string Description,
        // ? meaning: nullable
        string? ImageUrl) : IEntity
    {
        
    }
}
