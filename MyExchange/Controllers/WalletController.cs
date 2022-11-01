using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.BusinessLogic.Interfaces;

namespace MyExchange.API.Controllers
{
    [Route("api/Wallet")]
    public class WalletController : BaseController
    {
        private readonly IWalletService _walletService;

        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }

        [HttpGet("{id}")]
        public async Task<WalletDto> GetWallet(int id)
        {
            var wallet = await _walletService.GetWallet(id);
            return wallet;
        }

        [HttpGet]
        public async Task<IEnumerable<WalletDto>> GetAllWallets()
        {
            var users = await _walletService.GetAllWallets();
            return users;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWallet(WalletDto walletDto)
        {
            var _walletDto = await _walletService.CreateWallet(walletDto);
            return CreatedAtAction(nameof(GetWallet), new { id = _walletDto.Id }, _walletDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWallet(int id, WalletUpdateDto walletDto)
        {
            await _walletService.UpdateWallet(id, walletDto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task DeleteWallet(int id)
        {
            await _walletService.DeleteWallet(id);
        }
    }
}
