using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Data.Repository;
using MyExchange.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Services;
using MyExchange.BusinessLogic.Dtos.Bank;

namespace MyExchange.API.Controllers
{
    [Route("api/Bank")]
    public class BankController : BaseController
    {
        private readonly IBankService _bankService;
        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BankDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBank(int id)
        {
            var bank = await _bankService.GetBank(id);
            if (bank == null)
            {
                return NotFound("No bank with such ID");
            }
            return Ok(bank);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BankDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BankDto>>> GetAllBanks()
        {
            var banks = await _bankService.GetAllBanks();
            if (!banks.Any())
            {
                return NotFound("Theres no banks");
            }
            return Ok(banks);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BankDto>> CreateBank(BankDto bankDto)
        {
            var _bankDto = await _bankService.CreateBank(bankDto);
            if (_bankDto == null)
            {
                return BadRequest("Cant create bank");
            }
            return CreatedAtAction(nameof(GetBank), new { id = _bankDto.Id }, _bankDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBank(int id)
        {
            try
            {
                await _bankService.DeleteBank(id);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
