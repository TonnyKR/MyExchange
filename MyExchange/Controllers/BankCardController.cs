using MyExchange.BusinessLogic.Interfaces;
using MyExchange.Data.Repository;
using MyExchange.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using MyExchange.BusinessLogic.Services;
using MyExchange.Common.Dtos.Currency;
using MyExchange.Common.Dtos.BankCard;

namespace MyExchange.API.Controllers
{
    [Route("api/BankCard")]
    public class BankCardController : BaseController
    {
        private readonly IBankCardService _bankCardService;
        public BankCardController(IBankCardService bankCardService)
        {
               _bankCardService= bankCardService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BankCardDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetBankCard(int id)
        {
            var card = await _bankCardService.GetBankCard(id);
            if (card == null)
            {
                return NotFound("No card with such ID");
            }
            return Ok(card);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<BankCardDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<BankCardDto>>> GetAllBankCards()
        {
            var cards = await _bankCardService.GetAllBankCards();
            if (!cards.Any())
            {
                return NotFound("Theres no bank cards");
            }
            return Ok(cards);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BankCardDto>> CreateBankCard(BankCardDto bankCardDto)
        {
            var cardDto = await _bankCardService.CreateBankCard(bankCardDto);
            if (cardDto == null)
            {
                return BadRequest("Cant create card");
            }
            return CreatedAtAction(nameof(GetBankCard), new { id = cardDto.Id }, cardDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBankCard(int id)
        {
            try
            {
                await _bankCardService.DeleteBankCard(id);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

        }
    }
}
