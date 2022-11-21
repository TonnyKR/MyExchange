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
        Task<UserDto> GetUser(string id);
        Task<IEnumerable<UserDto>> GetAllUsers();

        Task<UserDto> CreateUser(UserDto userDto);

        Task UpdateUser(string id, UserUpdateDto userDto);

        Task DeleteUser(string id);
    }
}
