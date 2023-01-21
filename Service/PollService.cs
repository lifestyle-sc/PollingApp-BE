using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
    internal sealed class PollService : IPollService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager; 

        public PollService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<PollDto> CreatePollForUserAsync(Guid userId, PollForCreationDto pollForCreation)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if(user == null)
                throw new UserNotFoundException(userId);

            if (pollForCreation.Deadline <= DateTime.Now)
                throw new DeadlineParameterBadRequestException(pollForCreation.Deadline);

            var poll = _mapper.Map<Poll>(pollForCreation);

            _repository.Poll.CreatePollForUser(userId, poll);

            await _repository.SaveAsync();

            var pollToReturn = _mapper.Map<PollDto>(poll);

            return pollToReturn;
        }

        public async Task<IEnumerable<PollDto>> GetPollsForUserAsync(Guid userId, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UserNotFoundException(userId);

            var polls = await _repository.Poll.GetPollsForUserAsync(userId, trackChanges);

            var pollsToReturn = _mapper.Map<IEnumerable<PollDto>>(polls);

            return pollsToReturn;
        }

        public async Task<PollDto> GetPollForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UserNotFoundException(userId);

            var poll = await _repository.Poll.GetPollForUserAsync(userId, id, trackChanges);

            if (poll == null)
                throw new PollNotFoundException(id);

            var pollToReturn = _mapper.Map<PollDto>(poll);

            return pollToReturn;
        }

        public async Task<IEnumerable<PollDto>> GetPollsByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId);

            if (ids == null)
                throw new IdsParameterBadRequest();

            var pollEntities = await _repository.Poll.GetPollsByIdsForUserAsync(userId, ids, trackChanges);

            if(pollEntities.Count() != ids.Count())
                throw new CollectionByIdsBadRequest();

            var pollToReturn = _mapper.Map<IEnumerable<PollDto>>(pollEntities);

            return pollToReturn;
        }

        public async Task<(IEnumerable<PollDto> pollsToReturn, string ids)> CreatePollCollectionForUserAsync(Guid userId, IEnumerable<PollForCreationDto> pollsForCreation)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());

            if (user == null)
                throw new UserNotFoundException(userId);

            if (pollsForCreation is null)
                throw new PollCollectionBadRequest();

            var pollsEntity = _mapper.Map<IEnumerable<Poll>>(pollsForCreation);

            foreach (var poll in pollsEntity)
            {
                _repository.Poll.CreatePollForUser(userId, poll);
            }

            await _repository.SaveAsync();

            var pollsToReturn = _mapper.Map<IEnumerable<PollDto>>(pollsEntity);

            var ids = string.Join(",", pollsToReturn.Select(p => p.Id));

            return (pollsToReturn, ids);
        }

        public async Task DeletePollForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId);

            var pollEntity = await _repository.Poll.GetPollForUserAsync(userId, id, trackChanges);
            if(pollEntity == null)
                throw new PollNotFoundException(id);

            _repository.Poll.DeletePollForUser(pollEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdatePollForUserAsync(Guid userId, Guid id, PollForUpdateDto pollForUpdate, bool pollTrackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId);

            var pollEntity = await _repository.Poll.GetPollForUserAsync(userId, id, pollTrackChanges);
            if (pollEntity == null)
                throw new PollNotFoundException(id);

            _mapper.Map(pollForUpdate, pollEntity);

            await _repository.SaveAsync();
        }

        public async Task<(PollForUpdateDto pollForPatch, Poll pollEntity)> GetPollForPatchAsync(Guid userId, Guid id, bool pollTrackChanges)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                throw new UserNotFoundException(userId);

            var pollEntity = await _repository.Poll.GetPollForUserAsync(userId, id, pollTrackChanges);
            if (pollEntity == null)
                throw new PollNotFoundException(id);

            var pollForPatch = _mapper.Map<PollForUpdateDto>(pollEntity);

            return (pollForPatch, pollEntity);
        }

        public async Task SaveChangesForPatchAsync(PollForUpdateDto pollForPatch, Poll pollEntity)
        {
            _mapper.Map(pollForPatch, pollEntity);

            await _repository.SaveAsync();
        }
    }
}
