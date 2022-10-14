﻿using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Repository;
using MyExchange.Domain.Entities;

namespace MyExchange.API.Controllers
{
    [Route ("api/User")]
    public class UserController :BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("{id}")]
        public async Task<UserDto> GetUser(int id)
        {
            var user = await _userService.GetUser(id);
            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            var _userDto = await _userService.CreateUser(userDto);

            return CreatedAtAction(nameof(GetUser), new { id = _userDto.Id }, _userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UserUpdateDto userDto)
        {
            await _userService.UpdateUser(id, userDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }
    }
}

