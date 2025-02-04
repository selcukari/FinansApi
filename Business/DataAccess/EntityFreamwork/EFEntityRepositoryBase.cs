using Business.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccess.EntityFreamwork
{
    public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        void IEntityRepository<TEntity>.Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IEntityRepository<TEntity>.AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<TEntity>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        TEntity IEntityRepository<TEntity>.Get(Expression<Func<TEntity, bool>> filter, bool noTrack)
        {
            throw new NotImplementedException();
        }

        List<TEntity> IEntityRepository<TEntity>.GetList(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        void IEntityRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
