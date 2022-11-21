using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.User;
using MyExchange.Data.Repository;
using MyExchange.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MyExchange.API.Controllers
{
    [Route ("api/User")]
    public class UserController :BaseController
    {
        private readonly IUserService _userService;
        private readonly IWalletService _walletService;
        public UserController(IUserService userService, IWalletService walletService)
        {
            _userService = userService;
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userService.GetUser(id);
            if (user == null)
            {
                return NotFound("No user with such ID");
            }
            return Ok(user);
         }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            if (!users.Any())
            {
                return NotFound("Theres no users");
            }
            return Ok(users);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var _userDto = await _userService.CreateUser(userDto);
            var walletDto = await _walletService.CreateDefaultWallet(_userDto);
            if (_userDto == null || walletDto == null)
            {
                return BadRequest("Cant create user");
            }
            return CreatedAtAction(nameof(GetUser), new { id = _userDto.Id }, _userDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateUser(string id, UserUpdateDto userDto)
        {
            try {
                await _userService.UpdateUser(id, userDto);
                return Ok(); 
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(string id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return Ok();
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
        }
    }
}

