using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceManager _services;
        public AuthenticationController(IServiceManager services) => _services = services;
    }
}
