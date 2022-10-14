using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.WalletBalance;

namespace MyExchange.API.Controllers
{
    [Route("api/WalletBalance")]
    public class WalletBalanceController : BaseController
    {
        private readonly IWalletBalanceService _walletBalanceService;
        public WalletBalanceController(IWalletBalanceService walletBalanceService)
        {
             _walletBalanceService = walletBalanceService;
        }
        [HttpGet("{id}")]
        public async Task<WalletBalanceDto> GetBalance(int id)
        {
            var balance = await _walletBalanceService.GetWalletBalance(id);
            return balance;
        }

        [HttpGet]
        public async Task<IEnumerable<WalletBalanceDto>> GetAllWalletBalances()
        {
            var balances = await _walletBalanceService.GetAllWalletBalances();
            return balances;
        }

        [HttpPut("recieveUAH/{id}")]
        public async Task<IActionResult> RecieveUAH(int id, [FromBody] decimal UAH)
        {
            await _walletBalanceService.RecieveUAH(id, UAH);
            return Ok();
        }

        [HttpPut("transmitUAH/{id}")]
        public async Task<IActionResult> TransmitUAH(int id, [FromBody] decimal UAH)
        {
            await _walletBalanceService.TransmitUAH(id, UAH);
            return Ok();
        }

        [HttpPut("recieveUSD/{id}")]
        public async Task<IActionResult> RecieveUSD(int id, [FromBody] decimal USD)
        {
            await _walletBalanceService.RecieveUSD(id, USD);
            return Ok();
        }

        [HttpPut("transmitUSD/{id}")]
        public async Task<IActionResult> TransmitUSD(int id, [FromBody] decimal USD)
        {
            await _walletBalanceService.TransmitUSD(id, USD);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWalletBalance(int id, WalletBalanceUpdateDto walletBalanceDto)
        {
            await _walletBalanceService.UpdateBallance(id, walletBalanceDto);
            return Ok();
        }
    }
}
