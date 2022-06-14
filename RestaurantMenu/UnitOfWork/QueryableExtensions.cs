﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RestaurantMenu.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.DAL.UnitOfWork
{
    public static class QueryableExtensions
    {
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
