using AutoMapper;
using RestaurantMenu.DAL.Entities;


namespace RestaurantMenu.DAL.UnitOfWork
{
    /* 
     * Mediates between the domain(rest of application) and the data mapping layers (DAL) 
     * using a collection-like interface for accessing domain objects.
     */
    public interface IRepository<TEntity> where TEntity : class, IEntity    
    {
        // IQueryable doc : https://docs.microsoft.com/en-us/dotnet/api/system.linq.iqueryable-1?view=net-6.0
        /* 
         * Provides functionality to evaluate queries against a specific data source wherein
         * the type of data is known.
         */
        IQueryable<TEntity> Get();
        void Delete(Guid entityId);
        Task<TEntity> InsertOrUpdateAsync<TModel>(
            TModel model,
            IMapper mapper,
            CancellationToken cancellationToken = default) where TModel : class;
    }
}
