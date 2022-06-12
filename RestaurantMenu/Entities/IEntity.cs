using System;

// Interface annotating entities
// If Entity implements IEntity -> property Id exists in entity
namespace RestaurantMenu.DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
