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

        public async Task<CandidateDto> CreateCandidateForPollAsync(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation, bool trackChanges)
        {
            var poll = await _repository.Poll.GetPollForUserAsync(userId, pollId, trackChanges);

            if (poll == null)
                throw new PollNotFoundException(pollId);

            var candidate = _mapper.Map<Candidate>(candidateForCreation);

            _repository.Candidate.CreateCandidateForPoll(pollId, candidate);

            await _repository.SaveAsync();

            var candidateToReturn = _mapper.Map<CandidateDto>(candidate);

            return candidateToReturn;
        }

        public async Task<CandidateDto> GetCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges)
        {
            var poll = await _repository.Poll.GetPollForUserAsync(userId, pollId, pollTrackChanges);

            if (poll == null)
                throw new PollNotFoundException(pollId);

            var candidateEntity = await _repository.Candidate.GetCandidateForPollAsync(pollId, id, candTrackChanges);

            if (candidateEntity == null)
                throw new CandidateNotFoundException(id);

            var candidateToReturn = _mapper.Map<CandidateDto>(candidateEntity);

            return candidateToReturn;

        }
    }
}
