using Microsoft.AspNetCore.Mvc;
using SwaggerExample.Attributes;
using SwaggerExample.Models.DTO.Users;
using SwaggerExample.Services;

namespace SwaggerExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(RequestAuthenticate model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [JWTAuthorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();

            return Ok(users);
        }
    }
}