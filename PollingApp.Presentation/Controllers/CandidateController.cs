using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/users/{userId}/polls/{pollId}/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CandidateController(IServiceManager services) => _services = services;
    }
}
