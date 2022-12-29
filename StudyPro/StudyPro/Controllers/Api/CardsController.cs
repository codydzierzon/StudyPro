using Microsoft.AspNetCore.Mvc;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Data;
using StudyPro.Services.Data;

namespace StudyPro.Controllers.Api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CardsController : ControllerBase

    {
        private ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCards()
        {
            try
            {
                var cards = await _cardService.GetAllAsync();
                return Ok(cards);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardsByCategory([FromRoute] int id)
        {
            var cards = await _cardService.GetCardsByCategoryIDAsync(id);
            return Ok(cards);
        }

        [HttpPost("")]
        public async Task<IActionResult> addCard(Card card)
        {
            var addCard = await _cardService.AddCardAsync(card);
            return StatusCode(201, addCard);
        }

        [HttpDelete("edit/{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute] int id)
        {
            var card = await _cardService.GetByIDAsync(id);
            if (card == null)
            {
                return NotFound($"Card with {id} not found");
            }
            else
            {
                await _cardService.DeleteCardAsync(id);
                return NoContent();
            }
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateCard([FromRoute]int id,[FromBody] Card card)
        {
            var cardUpdate = await _cardService.GetByIDAsync(id);
            if (cardUpdate == null)
            {
                return NotFound($"Card with {id} not found");
            }
            else
            {
                await _cardService.UpdateCardAsync(id, card);
                return Ok();
            }
        }
    }
}
