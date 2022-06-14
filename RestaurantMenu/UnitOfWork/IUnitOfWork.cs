using RestaurantMenu.DAL.Entities;


namespace RestaurantMenu.DAL.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
        Task CommitAsync();
    }
}
