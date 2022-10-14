using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Interfaces;
using MyExchange.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExchange.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);

            user.Wallet = new Wallet { User = user,WalletBalance = new WalletBalance() , WalletStatistic = new WalletStatistic() };
            _repository.Add(user);
            await _repository.SaveChangesAsync();

            var _userDto = _mapper.Map<UserDto>(user);

            return _userDto;
        }

        public async Task DeleteUser(int id)
        {
            await _repository.Delete<User>(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userList = await _repository.GetAll<User>();
            var userDtoList = _mapper.Map<List<UserDto>>(userList);
            return userDtoList;
        }

        public async Task<UserDto> GetUser(int id)
        {
            var user = await _repository.GetById<User>(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task UpdateUser(int id, UserUpdateDto userDto)
        {
            var user = await _repository.GetById<User>(id);
            _mapper.Map<UserUpdateDto>(user);
            await _repository.SaveChangesAsync();
        }
    }
}
