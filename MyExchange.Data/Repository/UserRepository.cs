using Microsoft.EntityFrameworkCore;
using MyExchange.Data.Entities;
using MyExchange.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyExchangeContext myExchangeDbContext;
        public UserRepository(MyExchangeContext DbContext)
        {
            myExchangeDbContext = DbContext;
        }
        public void Add(User entity)
        {
            myExchangeDbContext.Users.Add(entity);
        }

        public async Task<User> Delete(string id)
        {
            var entity = await myExchangeDbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null)
            {
                throw new ArgumentNullException(); //ValidationException($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            myExchangeDbContext.Users.Remove(entity);

            return entity;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await myExchangeDbContext.Users.ToListAsync();
        }

        public async Task<User> GetById(string id)
        {
            return await myExchangeDbContext.Users.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task SaveChangesAsync()
        {
            await myExchangeDbContext.SaveChangesAsync();
        }
    }
}
