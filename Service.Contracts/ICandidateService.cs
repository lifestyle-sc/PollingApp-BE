using Shared.DTOs;

namespace Service.Contracts
{
    public interface ICandidateService
    {
        Task<CandidateDto> CreateCandidateForPollAsync(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation, bool trackChanges);
        Task<CandidateDto> GetCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool trackChanges);
    }
}
