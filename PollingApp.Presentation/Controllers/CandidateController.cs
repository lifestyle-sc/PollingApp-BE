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

        [HttpGet("{id:guid}", Name = "GetCandidateForPoll")]
        public async Task<IActionResult> GetCandidateForPoll(Guid userId, Guid pollId, Guid id)
        {
            var candidateToReturn = await _services.CandidateService.GetCandidateForPollAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: false);

            return Ok(candidateToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidateForPoll(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation)
        {
            var candidateToReturn = await _services.CandidateService.CreateCandidateForPollAsync(userId, pollId, candidateForCreation, trackChanges: false);

            return Ok(candidateToReturn);
        }
    }
}
