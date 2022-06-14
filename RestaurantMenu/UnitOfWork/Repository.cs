using AutoMapper;
using AutoMapper.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantMenu.DAL.Entities;


// Automapper doc: https://docs.automapper.org/en/stable/Getting-started.html


namespace RestaurantMenu.DAL.UnitOfWork
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly IModel _model;

        public Repository(DbContext dbContext)
        {
            /* 
             * Set method doc : https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbcontext.set?view=entity-framework-6.2.0#definition
             * Returns a non-generic DbSet instance for access to entities of the given 
             * type in the context. 
             * DbSet doc : https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset?view=entity-framework-6.2.0
             * A non-generic version of DbSet<TEntity> wich can be used when the type
             * of entity is not known at build time.
             */
            _dbSet = dbContext.Set<TEntity>();
            /* 
             *  Model property doc : https://docs.microsoft.com/en-us/dotnet/api/microsoft.entityframeworkcore.dbcontext.model?view=efcore-6.0
             *  The metadata about the shape of entities, the relationship between them,
             *  and how they map in the database. 
             */
            _model = dbContext.Model;
        }

        public IQueryable<TEntity> Get() => _dbSet;
        
        public async Task<TEntity> InsertOrUpdateAsync<TModel>(
            TModel model,
            IMapper mapper,
            CancellationToken cancellationToken = default) where TModel : class
        {
            await _dbSet.PreLoadChangeTracker(mapper.Map<TEntity>(model).Id, _model, cancellationToken);

            return await _dbSet.Persist(mapper).InsertOrUpdateAsync(model, cancellationToken);
        }

        public void Delete(Guid entityId) => _dbSet.Remove(_dbSet.Single(i => i.Id == entityId));
    }
}
