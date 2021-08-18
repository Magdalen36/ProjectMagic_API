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
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("[action]")]
        public ActionResult<UserPublicModel> Login(string email, string password)
        {
            try
            {
                UserPublicModel user = _userService.Check(email, password);
                if(user is null) return StatusCode(StatusCodes.Status401Unauthorized, "L'email et le mot de passe ne correspondent à aucun profil.");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    Method = nameof(Login),
                    Message = ex.Message
                });
            }
        }


        [HttpPost]
        public ActionResult Post([FromBody] UserModel user)
        {
            try
            {
                if (user is null) return BadRequest();
                return Ok(_userService.Insert(user));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = "Post", Message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                return Ok(_userService.Delete(id));
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        new { Method = nameof(Delete), Message = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
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
                UserPublicModel result = _userService.GetById(id);
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
