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
        public IActionResult GetAll()
        {
            return Ok(_editionService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_editionService.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] EditionModel edition)
        {
            return Ok(_editionService.Insert(edition));
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EditionModel edition)
        {
            try
            {
                edition.Id = id;
                _editionService.Update(edition, id);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest("Echec de la mise à jour");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(_editionService.Delete(id));
        }
    }
}
