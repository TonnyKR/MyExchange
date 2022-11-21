using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Data.Repository;
using MyExchange.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Services;
using MyExchange.Common.Dtos.Currency;
using MyExchange.BusinessLogic.Dtos.Wallet;

namespace MyExchange.API.Controllers
{
    [Route("api/Currency")]
    public class CurrencyController : BaseController
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrency(int id)
        {
            var currency = await _currencyService.GetCurrency(id);
            if (currency == null)
            {
                return NotFound("No currency with such ID");
            }
            return Ok(currency);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CurrencyDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<CurrencyDto>>> GetAllCurrenciess()
        {
            var currencies = await _currencyService.GetAllCurrencies();
            if (!currencies.Any())
            {
                return NotFound("Theres no currencies");
            }
            return Ok(currencies);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CurrencyDto>> CreateCurrency(CurrencyDto currencyDto)
        {
            var _currencyDto = await _currencyService.CreateCurrency(currencyDto);
            if (_currencyDto == null)
            {
                return BadRequest("Cant create currency");
            }
            return CreatedAtAction(nameof(GetCurrency), new { id = _currencyDto.Id }, _currencyDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCurrency(int id, CurrencyUpdateDto currencyDto)
        {
            try
            {
                await _currencyService.UpdateCurrency(id, currencyDto);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            try
            {
                await _currencyService.DeleteCurrency(id);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
