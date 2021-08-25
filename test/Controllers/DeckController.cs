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
    public class DeckController : ControllerBase
    {
        private DeckService _deckService;

        public DeckController(DeckService ds)
        {
            _deckService = ds;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_deckService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult DeckUser(int id)
        {
            try
            {
                return Ok(_deckService.GetAllByUserId(id));
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
                DeckModel result = _deckService.GetById(id);
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
        public ActionResult Post([FromBody] DeckModel deck)
        {
            try
            {
                if (deck is null) return BadRequest();
                return Ok(_deckService.Insert(deck));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] DeckModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                if (id != edition.Id) return BadRequest();

                edition.Id = id;
                _deckService.Update(edition, id);
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
                return Ok(_deckService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }
    }
}
