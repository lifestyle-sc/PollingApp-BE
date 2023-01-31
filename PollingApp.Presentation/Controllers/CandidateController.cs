using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PollingApp.Presentation.ActionFilters;
using Service.Contracts;
using Shared.DTOs;
using Shared.RequestFeatures;
using System.Text.Json;

namespace PollingApp.Presentation.Controllers
{
    [Route("api/users/{userId}/polls/{pollId}/candidates")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IServiceManager _services;

        public CandidateController(IServiceManager services) => _services = services;

        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetCandidatesForPoll(Guid userId, Guid pollId, [FromQuery] CandidateParameters candidateParameters)
        {
            var pagedResult = await _services.CandidateService.GetCandidatesForPollAsync(userId, pollId, candidateParameters, pollTrackChanges: false, candTrackChanges: false);

            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(pagedResult.metaData));

            return Ok(pagedResult.candidatesToReturn);
        }

        [HttpGet("{id:guid}", Name = "GetCandidateForPoll")]
        public async Task<IActionResult> GetCandidateForPoll(Guid userId, Guid pollId, Guid id)
        {
            var candidateToReturn = await _services.CandidateService.GetCandidateForPollAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: false);

            return Ok(candidateToReturn);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateCandidateForPoll(Guid userId, Guid pollId, [FromBody] CandidateForCreationDto candidateForCreation)
        {
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
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateCandidateForPoll(Guid userId, Guid pollId, Guid id, [FromBody]CandidateForUpdateDto candidateForUpdate)
        {
            await _services.CandidateService.UpdateCandidateForPollAsync(userId, pollId, id, candidateForUpdate, pollTrackChanges: false, candTrackChanges: true);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdateCandidateForPoll(Guid userId, Guid pollId, Guid id, [FromBody] JsonPatchDocument<CandidateForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("The patchDoc sent by the client is null.");

            var result = await _services.CandidateService.GetCandidateForPatchAsync(userId, pollId, id, pollTrackChanges: false, candTrackChanges: true);

            patchDoc.ApplyTo(result.candidateForPatch, ModelState);

            TryValidateModel(result.candidateForPatch);
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.CandidateService.SaveChangesForPatchAsync(result.candidateForPatch, result.candidateEntity);

            return NoContent();
        }

        [HttpOptions]
        public IActionResult GetCandidatesOptions()
        {
            Response.Headers.Add("Allow", "GET, POST, PUT DELETE, PATCH, HEAD, OPTIONS");

            return Ok();
        }
    }
}
