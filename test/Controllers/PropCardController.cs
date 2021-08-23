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
    [ApiController]
    [Route("[controller]")]
    public class PropCardController : ControllerBase
    {
        private ColorService _colorService;
        private RarityService _rarityService;
        private TypeService _typeService;
        private SousTypeService _sousTypeService;

        public PropCardController(ColorService cs, RarityService rs, TypeService ts, SousTypeService sts)
        {
            _colorService = cs;
            _rarityService = rs;
            _typeService = ts;
            _sousTypeService = sts;
        }

        [HttpGet("[action]")]
        public ActionResult GetAllColors()
        {
            try
            {
                return Ok(_colorService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetByIdColors(int id)
        {
            try
            {
                ColorModel result = _colorService.GetById(id);
                if (result is null) return NotFound();
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public ActionResult GetAllRarity()
        {
            try
            {
                return Ok(_rarityService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetByIdRarity(int id)
        {
            try
            {
                RarityModel result = _rarityService.GetById(id);
                if (result is null) return NotFound();
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public ActionResult GetAllTypes()
        {
            try
            {
                return Ok(_typeService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetByIdTypes(int id)
        {
            try
            {
                TypeModel result = _typeService.GetById(id);
                if (result is null) return NotFound();
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]")]
        public ActionResult GetAllSousType()
        {
            try
            {
                return Ok(_sousTypeService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }

        [HttpGet("[action]/{id}")]
        public ActionResult GetByIdSousType(int id)
        {
            try
            {
                SousTypeModel result = _sousTypeService.GetById(id);
                if (result is null) return NotFound();
                else return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Get", Message = ex.Message });
            }
        }
    }
}
