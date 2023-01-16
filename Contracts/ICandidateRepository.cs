using Entities.Models;

namespace Contracts
{
    public interface ICandidateRepository
    {
        void CreateCandidateForPoll(Guid pollId, Candidate candidate);

        Task<Candidate> GetCandidateForPollAsync(Guid pollId, Guid id, bool trackChanges);
    }
}
