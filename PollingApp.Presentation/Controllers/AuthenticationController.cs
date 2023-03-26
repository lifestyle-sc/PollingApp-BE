using Microsoft.AspNetCore.Mvc;
using PollingApp.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DTOs;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _services;
        public AuthenticationController(IServiceManager services) => _services = services;

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForReg)
        {
            var result = await  _services.AuthenticationService.RegisterUser(userForReg);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }

            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthDto userForAuth)
        {
            if(!await _services.AuthenticationService.ValidateUser(userForAuth))
                return Unauthorized();

            return Ok(new { Token = await _services.AuthenticationService.CreateToken() });
        }
    }
}
