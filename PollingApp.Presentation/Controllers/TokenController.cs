using Microsoft.AspNetCore.Mvc;
using PollingApp.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DTOs;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IServiceManager _services;

        public TokenController(IServiceManager services) => _services = services;

        [HttpPost("refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh([FromBody] TokenDto tokens)
        {
            var tokenToReturn = await _services.AuthenticationService.RefreshToken(tokens);

            return Ok(tokenToReturn);
        }
    }
}
