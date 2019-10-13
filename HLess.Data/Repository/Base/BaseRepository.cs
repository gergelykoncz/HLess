using HLess.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HLess.Data.Repository.Base
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly HLessDataContext context;

        public BaseRepository(HLessDataContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Template method for adding includes.
        /// </summary>
        /// <returns></returns>
        protected virtual IQueryable<TEntity> CreateQuery()
        {
            return this.context.Set<TEntity>();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            entity.Deleted = true;
            await this.UpdateAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var results = await this.CreateQuery().ToListAsync();
            return results;
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> criteria)
        {
            var results = await this.CreateQuery().Where(criteria).ToListAsync();
            return results;
        }

        public async Task<TEntity> GetOneByAsync(Expression<Func<TEntity, bool>> criteria)
        {
            var result = await this.CreateQuery().FirstOrDefaultAsync(criteria);
            return result;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            using (var tran = await this.context.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                this.context.Set<TEntity>().Add(entity);
                await this.context.SaveChangesAsync().ConfigureAwait(false);
                tran.Commit();
                return entity;
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            using (var tran = await this.context.Database.BeginTransactionAsync().ConfigureAwait(false))
            {
                if (entity.Id == new Guid())
                {
                    this.context.Set<TEntity>().Add(entity);
                    await this.context.SaveChangesAsync().ConfigureAwait(false);
                    tran.Commit();
                    return entity;
                }
                else
                {
                    var original = await this.GetOneByAsync(x => x.Id == entity.Id).ConfigureAwait(false);
                    this.context.Entry(original).CurrentValues.SetValues(entity);
                    await this.context.SaveChangesAsync().ConfigureAwait(false);
                    tran.Commit();
                    return entity;
                }
            }
        }
    }
}
