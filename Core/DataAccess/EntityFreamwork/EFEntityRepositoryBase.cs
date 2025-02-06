using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFreamwork
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        private readonly TContext _context;
        public EFEntityRepositoryBase(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, bool noTrack = false)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
