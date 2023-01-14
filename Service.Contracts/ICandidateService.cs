using Shared.DTOs;

namespace Service.Contracts
{
    public interface ICandidateService
    {
        Task<CandidateDto> CreateCandidateForPollAsync(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation, bool trackChanges);
    }
}
