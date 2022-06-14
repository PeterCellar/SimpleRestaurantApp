﻿using Microsoft.EntityFrameworkCore;
using RestaurantMenu.DAL.Entities;

namespace RestaurantMenu.DAL.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext) => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity => new Repository<TEntity>(_dbContext);
        
        public async Task CommitAsync() => await _dbContext.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _dbContext.DisposeAsync();
    }
}
