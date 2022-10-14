using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.WalletPosition;

namespace MyExchange.API.Controllers
{
    [Route("api/WalletPosition")]
    public class WalletPositionController : BaseController
    {
        private readonly IWalletPositionService _walletPositionService;

        public WalletPositionController(IWalletPositionService walletPosition)
        {
            _walletPositionService = walletPosition;
        }


        [HttpGet("{id}")]
        public async Task<WalletPositionDto> GetWalletPosition(int id)
        {
            var user = await _walletPositionService.GetWalletPosition(id);
            return user;
        }

        [HttpGet]
        public async Task<IEnumerable<WalletPositionDto>> GetAllUsers()
        {
            var users = await _walletPositionService.GetAllWalletPositions();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWalletPosition(WalletPositionDto walletPositionDto)
        {
            var _positionDto = await _walletPositionService.CreateWalletPosition(walletPositionDto);

            return CreatedAtAction(nameof(GetWalletPosition), new { id = _positionDto.Id }, _positionDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, WalletPositionUpdateDto walletPositionDto)
        {
            await _walletPositionService.UpdateWalletPosition(id, walletPositionDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteWalletPosition(int id)
        {
            await _walletPositionService.DeleteWalletPosition(id);
        }
    }
}
