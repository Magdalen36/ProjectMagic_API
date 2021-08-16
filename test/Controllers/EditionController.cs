using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMagic_Model;
using ProjectMagic_Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMagic_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EditionController : ControllerBase
    {
        private EditionService _editionService;

        public EditionController(EditionService editionService)
        {
            _editionService = editionService;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_editionService.GetAll());
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
                EditionModel result = _editionService.GetById(id);
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
        public ActionResult Post([FromBody] EditionModel edition)
        {          
            try
            {
                if (edition is null) return BadRequest();
                return Ok(_editionService.Insert(edition));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] EditionModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                if (id != edition.Id) return BadRequest();

                edition.Id = id;
                _editionService.Update(edition, id);
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
                return Ok(_editionService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }

        [HttpGet("[action]/{name}")]
        public ActionResult<IEnumerable<EditionModel>> SearchByName(string name)
        {
            try
            {
                IEnumerable<EditionModel> editions = _editionService.SearchByName(name);
                if (editions is null || editions.Count() == 0) return NotFound();

                return Ok(editions);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(SearchByName), Message = ex.Message });
            }
        }

        
    }
}
