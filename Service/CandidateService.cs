using AutoMapper;
using Contracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.DTOs;

namespace Service
{
    internal sealed class CandidateService : ICandidateService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CandidateService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        private async Task CheckIfPollExistsAsync(Guid userId, Guid pollId, bool trackChanges)
        {
            var poll = await _repository.Poll.GetPollForUserAsync(userId, pollId, trackChanges);

            if (poll == null)
                throw new PollNotFoundException(pollId);
        }

        private async Task<Candidate> CheckIfCandidateExistsAndReturnItAsync(Guid pollId, Guid id, bool trackChanges)
        {
            var candidateEntity = await _repository.Candidate.GetCandidateForPollAsync(pollId, id, trackChanges);

            if (candidateEntity == null)
                throw new CandidateNotFoundException(id);

            return candidateEntity;
        }

        public async Task<CandidateDto> CreateCandidateForPollAsync(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation, bool trackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, trackChanges);

            var candidate = _mapper.Map<Candidate>(candidateForCreation);

            _repository.Candidate.CreateCandidateForPoll(pollId, candidate);

            await _repository.SaveAsync();

            var candidateToReturn = _mapper.Map<CandidateDto>(candidate);

            return candidateToReturn;
        }

        public async Task<CandidateDto> GetCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, pollTrackChanges);

            var candidateEntity = await CheckIfCandidateExistsAndReturnItAsync(pollId, id, candTrackChanges);

            var candidateToReturn = _mapper.Map<CandidateDto>(candidateEntity);

            return candidateToReturn;
        }

        public async Task<IEnumerable<CandidateDto>> GetCandidatesForPollAsync(Guid userId, Guid pollId, bool pollTrackChanges, bool candTrackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, pollTrackChanges);

            var candidateEntity = await _repository.Candidate.GetCandidatesForPollAsync(pollId, candTrackChanges);

            var candidateToReturn = _mapper.Map<IEnumerable<CandidateDto>>(candidateEntity);

            return candidateToReturn;
        }

        public async Task DeleteCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, pollTrackChanges);

            var candidateEntity = await CheckIfCandidateExistsAndReturnItAsync(pollId, id, candTrackChanges);

            _repository.Candidate.DeleteCandidateForPoll(candidateEntity);

            await _repository.SaveAsync();
        }

        public async Task UpdateCandidateForPollAsync(Guid userId, Guid pollId, Guid id, CandidateForUpdateDto candidateForUpdate, bool pollTrackChanges, bool candTrackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, pollTrackChanges);

            var candidateEntity = await CheckIfCandidateExistsAndReturnItAsync(pollId, id, candTrackChanges);

            _mapper.Map(candidateForUpdate, candidateEntity);

            await _repository.SaveAsync();
        }

        public async Task<(CandidateForUpdateDto candidateForPatch, Candidate candidateEntity)>GetCandidateForPatchAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges)
        {
            await CheckIfPollExistsAsync(userId, pollId, pollTrackChanges);

            var candidateEntity = await CheckIfCandidateExistsAndReturnItAsync(pollId, id, candTrackChanges);

            var candidateForPatch = _mapper.Map<CandidateForUpdateDto>(candidateEntity);

            return (candidateForPatch, candidateEntity);
        }

        public async Task SaveChangesForPatchAsync(CandidateForUpdateDto candidateForPatch, Candidate candidateEntity)
        {
            _mapper.Map(candidateForPatch, candidateEntity);

            await _repository.SaveAsync();
        }
    }
}
