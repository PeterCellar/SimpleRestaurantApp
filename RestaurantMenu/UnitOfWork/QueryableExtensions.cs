using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantMenu.DAL.Entities;


namespace RestaurantMenu.DAL.UnitOfWork
{
    public static class QueryableExtensions
    {
        // CancellationToken doc : https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken?view=net-6.0
        /* 
         * Propagates notification that operations should be cancdeled. 
         */

        public static async Task PreLoadChangeTracker<TEntity>(this IQueryable<TEntity> dbSet, Guid entityId, IModel model, CancellationToken cancellationToken) where TEntity : class, IEntity
            => await dbSet
            .IncludeFirstLevelNavigationProperties(model)
            .Where(e => e.Id == entityId)
            .FirstOrDefaultAsync(cancellationToken)
            .ConfigureAwait(false);

        public static IQueryable<TEntity> IncludeFirstLevelNavigationProperties<TEntity>(this IQueryable<TEntity> query, IModel model) where TEntity : class
        {
            var navigationProperties = model.FindEntityType(typeof(TEntity))?.GetNavigations();
            if (navigationProperties == null)
                return query;

            foreach (var navigationProperty in navigationProperties)
            {
                query = query.Include(navigationProperty.Name);
            }

            return query;
        }
    }
}
