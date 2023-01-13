using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTOs;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/users/{userId}/polls")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IServiceManager _services;

        public PollController(IServiceManager services) => _services = services;

        [HttpGet]
        public async Task<IActionResult> GetPollsForUser(Guid userId)
        {
            var polls = await _services.PollService.GetPollsForUserAsync(userId, trackChanges: false);

            return Ok(polls);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetPollForUser(Guid userId, Guid id)
        {
            var poll = await _services.PollService.GetPollForUserAsync(userId, id, trackChanges:false);

            return Ok(poll);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePollForUser(Guid userId, [FromBody] PollForCreationDto pollForCreation)
        {
            var pollToReturn = await _services.PollService.CreatePollForUserAsync(userId, pollForCreation);

            //return CreatedAtRoute("GetPollForUser", new { userId, id = pollToReturn.Id }, pollToReturn);
            return Ok(pollToReturn);
        }
    }
}
