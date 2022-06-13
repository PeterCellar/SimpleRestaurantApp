using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL.Entities;


namespace RestaurantMenu.Common.Tests.Seeds
{
    public static class IngredientSeeds
    {
        public static readonly IngredientEntity EmptyIngredient = new(
            Id: default,
            Name: default!,
            Description: default!,
            ImageUrl: default!);

        public static readonly IngredientEntity Water = new(
            Id: Guid.NewGuid(),
            Name: "Mango",
            Description: "Summer fruit",
            ImageUrl: "https://cdn.rohlik.cz/cdn-cgi/image/f=auto,w=650/https://cdn.rohlik.cz/uploads/M%C3%AD%C5%A1a/mango-1.jpeg");

        //To ensure that no tests reuse these clones for non-idempotent operations
        public static readonly IngredientEntity WaterUpdate = Water with { Id = Guid.Parse("143332B9-080E-4953-AEA5-BEF64679B052") };
        public static readonly IngredientEntity WaterDelete = Water with { Id = Guid.Parse("274D0CC9-A948-4818-AADB-A8B4C0506619") };

        public static readonly IngredientEntity IngredientEntity1 = new(
            Id: Guid.NewGuid(),
            Name: "Mango",
            Description: "Summer fruit",
            ImageUrl: "https://cdn.rohlik.cz/cdn-cgi/image/f=auto,w=650/https://cdn.rohlik.cz/uploads/M%C3%AD%C5%A1a/mango-1.jpeg");

        public static readonly IngredientEntity IngredientEntity2 = new(
           Id: Guid.NewGuid(),
           Name: "Orange",
           Description: "Summer fruit",
           ImageUrl: "https://cdn.rohlik.cz/cdn-cgi/image/f=auto,w=650/https://cdn.rohlik.cz/uploads/M%C3%AD%C5%A1a/mango-1.jpeg");




        // ModelBuilder documentation: https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.modelbuilder?view=efcore-6.0
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(Water);
        }
    }
}
