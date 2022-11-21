using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Dtos.Wallet;
using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Common.Dtos.WalletPosition;
using MyExchange.Data.Entities;

namespace MyExchange.API.Controllers
{
    [Route("api/Wallet")]
    public class WalletController : BaseController
    {
        private readonly IWalletService _walletService;
        private readonly IWalletPositionService _walletPositionService;
        private readonly ICurrencyService _currencyService;

        public WalletController(IWalletService walletService, IWalletPositionService walletPositionService, ICurrencyService currencyService)
        {
            _walletService = walletService;
            _walletPositionService = walletPositionService;
            _currencyService = currencyService;
        }

        [HttpPut]
        [Route("ReplenishBalance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ReplenisBalance(int WalletId, int BankCardId, decimal amount)
        {
            try
            {
                await _walletService.ReplenisBalance(WalletId, BankCardId, amount);
                return Ok();
            }
            catch(Exception ex) { return BadRequest(ex.Message); }
            
        }

        [HttpPut]
        [Route("WithdrawBalance")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> WithdrawBalance(int WalletId, int BankCardId, decimal amount)
        {
            try
            {
                await _walletService.WithdrawBalance(WalletId, BankCardId, amount);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        [Route("BuyCurrency")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> BuyCurrency(WalletPositionDto walletPositionDto)
        {
            try
            {
                var walletPositions = await _walletPositionService.GetWalletPositions(walletPositionDto.WalletId);
                var wallet = await _walletService.GetWallet(walletPositionDto.WalletId);
                var currency = await _currencyService.GetCurrency(walletPositionDto.CurrencyId);

                if (wallet.Balance < currency.PriceUsd * walletPositionDto.Quantity)
                {
                    return BadRequest("Balance lack money");
                }
                if (walletPositions.FirstOrDefault(p => p.CurrencyId == walletPositionDto.CurrencyId) != null)
                {
                    await _walletPositionService.AddToWalletPosition(walletPositionDto);
                    await _walletService.UpdateWallet(wallet.Id, new WalletUpdateDto { Balance = wallet.Balance - currency.PriceUsd * walletPositionDto.Quantity });
                    return Ok();
                }
                else
                {
                    await _walletPositionService.CreateWalletPosition(walletPositionDto);
                    await _walletService.UpdateWallet(wallet.Id, new WalletUpdateDto { Balance = wallet.Balance - currency.PriceUsd * walletPositionDto.Quantity });
                    return Ok();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost]
        [Route("SellCurrency")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SellCurrency(WalletPositionDto walletPositionDto)
        {
            try
            {
                var wallet = await _walletService.GetWallet(walletPositionDto.WalletId);
                var currency = await _currencyService.GetCurrency(walletPositionDto.CurrencyId);
                var walletPosition = (await _walletPositionService.GetWalletPositions(walletPositionDto.WalletId)).FirstOrDefault(p => p.CurrencyId == currency.Id);
                if (walletPosition == null)
                {
                    return BadRequest("No such currency in the wallet");
                }
                else if (walletPosition.Quantity < walletPositionDto.Quantity)
                {
                    return BadRequest("Not enough currency");
                }
                else
                {
                    await _walletPositionService.SellWalletPosition(walletPositionDto);
                    await _walletService.UpdateWallet(wallet.Id, new WalletUpdateDto { Balance = wallet.Balance + currency.PriceUsd * walletPositionDto.Quantity });
                    return Ok();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(WalletDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetWallet(int id)
        {
            var wallet = await _walletService.GetWallet(id);
            if (wallet == null)
            {
                return NotFound("No wallet with such ID");
            }
            return Ok(wallet);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WalletDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WalletDto>>> GetAllWallets()
        {
            var wallets = await _walletService.GetAllWallets();
            if (!wallets.Any())
            {
                return NotFound("Theres no wallets");
            }
            return Ok(wallets);
        }

        [HttpGet]
        [Route("GetAllWalletPositions")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<WalletPositionDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<WalletPositionDto>>> GetWalletPositions(int walletId)
        {
            var wallets = await _walletPositionService.GetWalletPositions(walletId);
            if (!wallets.Any())
            {
                return NotFound("Theres no wallets");
            }
            return Ok(wallets);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WalletDto>> CreateWallet(WalletDto walletDto)
        {
            var _walletDto = await _walletService.CreateWallet(walletDto);
            if (_walletDto == null)
            {
                return BadRequest("Cant create wallet");
            }
            return CreatedAtAction(nameof(GetWallet), new { id = _walletDto.Id }, _walletDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateWallet(int id, WalletUpdateDto walletDto)
        {
            try
            {
                await _walletService.UpdateWallet(id, walletDto);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteWallet(int id)
        {
            try
            {
                await _walletService.DeleteWallet(id);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
            
        }
    }
}
