using Entities.Models;

namespace Contracts
{
    public interface ICandidateRepository
    {
        void CreateCandidateForPoll(Guid pollId, Candidate candidate);
    }
}
