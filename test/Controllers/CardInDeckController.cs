using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMagic_Models;
using ProjectMagic_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMagic_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CardInDeckController : ControllerBase
    {
        private CardInDeckService _cardInDeckService;

        public CardInDeckController(CardInDeckService cs)
        {
            _cardInDeckService = cs;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_cardInDeckService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult CardsInDeck(int id)
        {
            try
            {
                return Ok(_cardInDeckService.GetAllByDeckId(id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            try
            {
                CardInDeckModel result = _cardInDeckService.GetById(id);
                if (result is null) return NotFound();
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] CardInDeckModel card)
        {
            try
            {
                if (card is null) return BadRequest();
                return Ok(_cardInDeckService.Insert(card));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] CardInDeckModel card)
        {
            try
            {
                if (card is null) return BadRequest();
                if (id != card.Id) return BadRequest();

                card.Id = id;
                _cardInDeckService.Update(card, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       new { Method = "Put", Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_cardInDeckService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }
    }
}
