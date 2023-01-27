using Entities.Models;
using Shared.DTOs;
using Shared.RequestFeatures;

namespace Service.Contracts
{
    public interface ICandidateService
    {
        Task<CandidateDto> CreateCandidateForPollAsync(Guid userId, Guid pollId, CandidateForCreationDto candidateForCreation, bool trackChanges);
        Task<CandidateDto> GetCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges);
        Task<(IEnumerable<CandidateDto> candidatesToReturn, MetaData metaData)> GetCandidatesForPollAsync(Guid userId, Guid pollId, CandidateParameters candidateParameters, bool pollTrackChanges, bool candTrackChanges);
        Task DeleteCandidateForPollAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges);
        Task UpdateCandidateForPollAsync(Guid userId, Guid pollId, Guid id, CandidateForUpdateDto candidateForUpdate, bool pollTrackChanges, bool candTrackChanges);
        Task<(CandidateForUpdateDto candidateForPatch, Candidate candidateEntity)> GetCandidateForPatchAsync(Guid userId, Guid pollId, Guid id, bool pollTrackChanges, bool candTrackChanges);
        Task SaveChangesForPatchAsync(CandidateForUpdateDto candidateForPatch, Candidate candidateEntity);
    }
}
