using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantMenu.DAL.UnitOfWork
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IDbContextFactory<RestaurantMenuDbContext> _dbContextFactory;

        public UnitOfWorkFactory(IDbContextFactory<RestaurantMenuDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public IUnitOfWork Create() => new UnitOfWork(_dbContextFactory.CreateDbContext());
    }
}
