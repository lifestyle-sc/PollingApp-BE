using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet]
        public async Task<IActionResult> GetCandidatesForPoll(Guid userId, Guid pollId)
        {
            var candidatesToReturn = await _services.CandidateService.GetCandidatesForPollAsync(userId, pollId, pollTrackChanges: false, candTrackChanges: false);

            return Ok(candidatesToReturn);
        }

        [HttpGet("{id:guid}", Name = "GetCandidateForPoll")]
        public async Task<IActionResult> GetCandidateForPoll(Guid userId, Guid pollId, Guid id)
        {
            var candidateToReturn = await _services.CandidateService.GetCandidateForPollAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: false);

            return Ok(candidateToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidateForPoll(Guid userId, Guid pollId, [FromBody] CandidateForCreationDto candidateForCreation)
        {
            if (candidateForCreation is null)
                return BadRequest("CandidateForCreationDto object is null");

            var candidateToReturn = await _services.CandidateService.CreateCandidateForPollAsync(userId, pollId, candidateForCreation, trackChanges: false);

            return CreatedAtRoute("GetCandidateForPoll", new { userId, pollId, id = candidateToReturn.Id }, candidateToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCandidateForPoll(Guid userId, Guid pollId, Guid id)
        {
            await _services.CandidateService.DeleteCandidateForPollAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: false);

            return NoContent();     
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateCandidateForPoll(Guid userId, Guid pollId, Guid id, [FromBody]CandidateForUpdateDto candidateForUpdate)
        {
            if (candidateForUpdate is null)
                return BadRequest("The candidateForPollDto object is null.");

            await _services.CandidateService.UpdateCandidateForPollAsync(userId, pollId, id, candidateForUpdate, pollTrackChanges: false, candTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateCandidateForPoll(Guid userId, Guid pollId, Guid id, [FromBody] JsonPatchDocument<CandidateForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("The patchDoc sent by the client is null.");

            var result = await _services.CandidateService.GetCandidateForPatchAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: true);

            patchDoc.ApplyTo(result.candidateForPatch);

            await _services.CandidateService.SaveChangesForPatchAsync(result.candidateForPatch, result.candidateEntity);

            return NoContent();
        }
    }
}
