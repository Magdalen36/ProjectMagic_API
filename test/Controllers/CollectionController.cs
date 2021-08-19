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
    public class CollectionController : ControllerBase
    {

        private CollectionService _collectionService;

        public CollectionController(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_collectionService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult CollectionUser(int id)
        {
            try
            {
                return Ok(_collectionService.GetAllByUserId(id));
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
                CollectionModel result = _collectionService.GetById(id);
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
        public ActionResult Post([FromBody] CollectionModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                return Ok(_collectionService.Insert(edition));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] CollectionModel edition)
        {
            try
            {
                if (edition is null) return BadRequest();
                if (id != edition.Id) return BadRequest();

                edition.Id = id;
                _collectionService.Update(edition, id);
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
                return Ok(_collectionService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }

    }
}
