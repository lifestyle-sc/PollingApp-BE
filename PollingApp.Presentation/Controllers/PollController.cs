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

        [HttpPost]
        public async Task<IActionResult> CreatePollForUser(Guid userId, [FromBody] PollForCreationDto pollForCreation)
        {
            var pollToReturn = await _services.PollService.CreatePollForUser(userId, pollForCreation);

            //return CreatedAtRoute("GetPollForUser", new { userId, id = pollToReturn.Id }, pollToReturn);
            return Ok(pollToReturn);
        }
    }
}
