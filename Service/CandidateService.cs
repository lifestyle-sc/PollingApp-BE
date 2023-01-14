using AutoMapper;
using Contracts;
using Entities.Exceptions;
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
        }
    }
}
