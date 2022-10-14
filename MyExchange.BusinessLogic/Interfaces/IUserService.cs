using MyExchange.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);
        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto> CreateUser(UserDto userDto);

        Task UpdateUser(int id, UserUpdateDto userDto);

        Task DeleteUser(int id);
    }
}
