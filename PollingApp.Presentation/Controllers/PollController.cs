﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PollingApp.Presentation.ModelBinders;
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

        [HttpGet("{id:guid}", Name = "GetPollForUser")]
        public async Task<IActionResult> GetPollForUser(Guid userId, Guid id)
        {
            var poll = await _services.PollService.GetPollForUserAsync(userId, id, trackChanges:false);

            return Ok(poll);
        }

        [HttpGet("collection/{ids}", Name = "GetPollsByIdsForUser")]
        public async Task<IActionResult> GetPollsByIdsForUser(Guid userId, [ModelBinder(BinderType = typeof(ArrayModelBinder))]IEnumerable<Guid> ids)
        {
            var pollToReturn = await _services.PollService.GetPollsByIdsForUserAsync(userId, ids, trackChanges:false);

            return Ok(pollToReturn);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePollForUser(Guid userId, [FromBody] PollForCreationDto pollForCreation)
        {
            if (pollForCreation is null)
                return BadRequest("The PollForCreationDto object sent from the client is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var pollToReturn = await _services.PollService.CreatePollForUserAsync(userId, pollForCreation);

            return CreatedAtRoute("GetPollForUser", new { userId, id = pollToReturn.Id }, pollToReturn);
        }

        [HttpPost("collection")]
        public async Task<IActionResult> CreatePollCollectionForUser(Guid userId, [FromBody] IEnumerable<PollForCreationDto> pollsForCreation)
        {
            if (pollsForCreation is null)
                return BadRequest("The PollsForCreationDto object sent from the client is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            var result = await _services.PollService.CreatePollCollectionForUserAsync(userId, pollsForCreation);

            return CreatedAtRoute("GetPollsByIdsForUser", new { userId, result.ids }, result.pollsToReturn);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdatePollForUser(Guid userId, Guid id, PollForUpdateDto pollForUpdate)
        {
            if (pollForUpdate is null)
                return BadRequest("The PollForUpdateDto object is null");

            if(!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            await _services.PollService.UpdatePollForUserAsync(userId, id, pollForUpdate, pollTrackChanges: true);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeletePollForUser(Guid userId, Guid id)
        {
            await _services.PollService.DeletePollForUserAsync(userId, id, trackChanges: false);

            return NoContent();
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PartiallyUpdatePollForUser(Guid userId, Guid id, [FromBody] JsonPatchDocument<PollForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("The patchDoc sent by the client is null.");

            var result = await _services.PollService.GetPollForPatchAsync(userId, id, pollTrackChanges: true);

            patchDoc.ApplyTo(result.pollForPatch);

            await _services.PollService.SaveChangesForPatchAsync(result.pollForPatch, result.pollEntity);

            return NoContent();
        }
    }
}
