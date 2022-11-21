using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);

        Task<IEnumerable<User>> GetAll();

        Task SaveChangesAsync();

        void Add(User entity);

        Task<User> Delete(string id);
    }
}
