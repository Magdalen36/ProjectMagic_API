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
    public class CardController : ControllerBase
    {

        private CardService _cardService;

        public CardController(CardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_cardService.GetAll());
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
                CardModel result = _cardService.GetById(id);
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
        public ActionResult Post([FromBody] CardModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                return Ok(_cardService.Insert(edition));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] CardModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                if (id != edition.Id) return BadRequest();

                edition.Id = id;
                _cardService.Update(edition, id);
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
                return Ok(_cardService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CardModel>> SearchByName(string name)
        {
            try
            {
                IEnumerable<CardModel> cards = _cardService.SearchByName(name);
                if (cards is null || cards.Count() == 0) return NotFound();

                return Ok(cards);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(SearchByName), Message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public ActionResult<IEnumerable<CardModel>> SearchByColor(int color)
        {
            try
            {
                IEnumerable<CardModel> cards = _cardService.SearchByColor(color);
                if (cards is null || cards.Count() == 0) return NotFound();

                return Ok(cards);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(SearchByName), Message = ex.Message });
            }
        }
    }
}
