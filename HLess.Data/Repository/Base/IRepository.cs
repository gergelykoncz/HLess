using HLess.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HLess.Data.Repository.Base
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> GetOneByAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
