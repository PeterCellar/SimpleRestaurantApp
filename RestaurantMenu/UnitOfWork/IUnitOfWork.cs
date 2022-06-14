using RestaurantMenu.DAL.Entities;


namespace RestaurantMenu.DAL.UnitOfWork
{
    // IAsyncDisposable doc: https://docs.microsoft.com/en-us/dotnet/api/system.iasyncdisposable?view=net-6.0
    /*
     *  Provides a mechanism for releasing unmanaged resources asynchronously.
     */
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task CommitAsync();
    }
}
