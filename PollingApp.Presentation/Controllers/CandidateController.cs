using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/users/{userId}/polls/{pollId}/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CandidateController(IServiceManager services) => _services = services;

        [HttpPost]
        public async Task<IActionResult> CreateCandidateForPoll(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation)
        {
            var candidateToReturn = await _services.CandidateService.CreateCandidateForPollAsync(userId, pollId, candidateForCreation, trackChanges: false);

            return Ok(candidateToReturn);
        }
    }
}
