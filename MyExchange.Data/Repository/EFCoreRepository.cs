using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyExchange.Data;
using MyExchange.Data.Interfaces;
using MyExchange.Domain.Entities;

namespace MyExchange.Data.Repository
{
    public class EFCoreRepository : IRepository
    {
        private readonly MyExchangeContext myExchangeDbContext;
        //private readonly IMapper _mapper;

        public EFCoreRepository(MyExchangeContext onlineBookShopDbContext/*,IMapper mapper*/)
        {
            myExchangeDbContext = onlineBookShopDbContext;
            //_mapper = mapper;
        }

        public async Task<List<TEntity>> GetAll<TEntity>() where TEntity : BaseEntity
        {
            return await myExchangeDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : BaseEntity
        {
            return await myExchangeDbContext.FindAsync<TEntity>(id);
        }

        //public async Task<TEntity> GetByIdWithInclude<TEntity>(int id, params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        //{
        //    var query = IncludeProperties(includeProperties);
        //    return await query.FirstOrDefaultAsync(entity => entity.Id == id);
        //}

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
            var entity = await myExchangeDbContext.Set<TEntity>().FindAsync(id);
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

        //private IQueryable<TEntity> IncludeProperties<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : BaseEntity
        //{
        //    IQueryable<TEntity> entities = myExchangeDbContext.Set<TEntity>();
        //    foreach (var includeProperty in includeProperties)
        //    {
        //        entities = entities.Include(includeProperty);
        //    }
        //    return entities;
        //}
    }
}
