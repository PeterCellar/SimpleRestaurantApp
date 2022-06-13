using System;

namespace RestaurantMenu.DAL.Entities
{
    // Represents Ingredient used in recipe
    // If we would use class then in tests reference types would be compared
    // Tests would fail
    // Record has value based comparison => automatic override methods for equality comparison
    public record IngredientEntity(
        Guid Id,
        string Name,
        string Description,
        // ? meaning: nullable
        string? ImageUrl) : IEntity
    {
        
    }
}
