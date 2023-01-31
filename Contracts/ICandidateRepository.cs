using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface ICandidateRepository
    {
        void CreateCandidateForPoll(Guid pollId, Candidate candidate);

        Task<Candidate> GetCandidateForPollAsync(Guid pollId, Guid id, bool trackChanges);
        Task<PagedList<Candidate>> GetCandidatesForPollAsync(Guid pollId, CandidateParameters candidateParameters, bool trackChanges);
        void DeleteCandidateForPoll(Candidate candidate);
    }
}
