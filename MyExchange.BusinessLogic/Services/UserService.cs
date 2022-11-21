using AutoMapper;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Interfaces;
using MyExchange.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyExchange.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDto> CreateUser(UserDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _repository.Add(user);
            await _repository.SaveChangesAsync();

            var returnDto = _mapper.Map<UserDto>(user);
            return returnDto;
        }

        public async Task DeleteUser(string id)
        {
            await _repository.Delete(id);
            await _repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var userList = await _repository.GetAll();
            var userDtoList = _mapper.Map<List<UserDto>>(userList);
            return userDtoList;
        }

        public async Task<UserDto> GetUser(string id)
        {
            var user = await _repository.GetById(id);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task UpdateUser(string id, UserUpdateDto userDto)
        {
            var user = await _repository.GetById(id);
            user = _mapper.Map(userDto, user);

            await _repository.SaveChangesAsync();
        }


    }
}
