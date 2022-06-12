using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL.Entities;

namespace RestaurantMenu.DAL.Seeds
{
    public static class IngredientSeeds
    {
        public static readonly IngredientEntity Water = new(
            Id: Guid.NewGuid(),
            Name: "Water",
            Description: "Mineral Water",
            ImageUrl: @"https://www.pngitem.com/pimgs/m/40-406527_cartoon-glass-of-water-png-glass-of-water.png"
            );

        public static readonly IngredientEntity Lemon = new(
            Id: Guid.NewGuid(),
            Name: "Lemon",
            Description: "Lemon from Spain",
            ImageUrl: @"https://www.eatthis.com/wp-content/uploads/sites/4/2020/02/lemons.jpg?quality=82&strip=1&resize=640%2C360"
            );

        public readonly static IngredientEntity Pork = new(
            Id: Guid.NewGuid(),
            Name: "Pork",
            Description: "Pork from british pigs",
            ImageUrl: @"https://www.tastingtable.com/img/gallery/every-cut-of-pork-ranked-worst-to-best/l-intro-1647527731.jpg"
            );

        public readonly static IngredientEntity Potato = new(
            Id: Guid.NewGuid(),
            Name: "Potato",
            Description: "Potatoes form Slovakia",
            ImageUrl: @"https://cdn.mos.cms.futurecdn.net/iC7HBvohbJqExqvbKcV3pP.jpg"
            );

        public readonly static IngredientEntity Onion = new(
            Id: Guid.NewGuid(),
            Name: "Onion",
            Description: "Onions from Czechia",
            ImageUrl: @"https://produits.bienmanger.com/34833-0w600h600_Organic_Yellow_Onion.jpg"
            );



        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IngredientEntity>().HasData(
                Water,
                Lemon,
                Pork,
                Potato,
                Onion);
        }
    }
}
