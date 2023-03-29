using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToToDiario.API.Application.Models;
using ToToDiario.API.Application.UserService;
using static ToToDiario.API.Domain.Enums.Enums;

namespace ToToDiario.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _userService.GetAllAsync(new CancellationToken());

            if(response.Result == ResultStatus.NoRecords)
            {
                return NoContent();
            }  
            return Ok(response);
            
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(UserRegisterDto newUser)
        {
            var response = await _userService.RegisterUserAsync(newUser, new CancellationToken());

            if (response.Result == ResultStatus.NoRecords)
            {
                return BadRequest();
            }
            return Created($"{response.UserId}", newUser);

        }
    }
}
