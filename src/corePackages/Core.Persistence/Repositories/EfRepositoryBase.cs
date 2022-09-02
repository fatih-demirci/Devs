using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TWriteContext, TReadContext> : IWriteRepository<TEntity>, IReadRepository<TEntity>
        where TEntity : Entity
        where TWriteContext : DbContext
        where TReadContext : DbContext
    {
        protected TReadContext ReadContext { get; }
        protected TWriteContext WriteContext { get; }

        public EfRepositoryBase(TWriteContext writeContext, TReadContext readContext)
        {
            ReadContext = readContext;
            WriteContext = writeContext;
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ReadContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                           Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                               null,
                                                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                               include = null,
                                                           int index = 1, int size = 10, bool enableTracking = true,
                                                           CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, 1, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, 1, cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                    Func<IQueryable<TEntity>,
                                                                            IIncludableQueryable<TEntity, object>>?
                                                                        include = null,
                                                                    int index = 1, int size = 10,
                                                                    bool enableTracking = true,
                                                                    CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return await queryable.ToPaginateAsync(index, size, 1, cancellationToken);
        }

        public IQueryable<TEntity> Query()
        {
            return ReadContext.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Added;
            await WriteContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Modified;
            await WriteContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Deleted;
            await WriteContext.SaveChangesAsync();
            return entity;
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return ReadContext.Set<TEntity>().FirstOrDefault(predicate);
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                          int index = 1, int size = 10,
                                          bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size);
            return queryable.ToPaginate(index, size, 1);
        }

        public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null, int index = 1, int size = 10,
                                                   bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            return queryable.ToPaginate(index, size, 1);
        }

        public TEntity Add(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Added;
            WriteContext.SaveChanges();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Modified;
            WriteContext.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            WriteContext.Entry(entity).State = EntityState.Deleted;
            WriteContext.SaveChanges();
            return entity;
        }

    }
}
