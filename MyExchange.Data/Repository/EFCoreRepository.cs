using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyExchange.Data;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;

namespace MyExchange.Data.Repository
{
    public class EFCoreRepository : IRepository
    {
        private readonly MyExchangeContext myExchangeDbContext;

        public EFCoreRepository(MyExchangeContext DbContext)
        {
            myExchangeDbContext = DbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await myExchangeDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await myExchangeDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await myExchangeDbContext.SaveChangesAsync();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            myExchangeDbContext
                .Set<TEntity>()
                .Add(entity);
        }

        public async Task<TEntity> Delete<TEntity>(int id) where TEntity : BaseEntity
        {
            var entity = await myExchangeDbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException(); //ValidationException($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            myExchangeDbContext.Set<TEntity>().Remove(entity);

            return entity;
        }

        //public async Task<PaginatedResult<TDto>> GetPagedData<TEntity, TDto>(PagedRequest pagedRequest) where TEntity : BaseEntity
        //                                                                                            where TDto : class
        //{
        //    return await myExchangeDbContext.Set<TEntity>().CreatePaginatedResultAsync<TEntity, TDto>(pagedRequest, _mapper);
        //}
    }
}
