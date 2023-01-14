using Contracts;
using Entities.Models;

namespace Repository
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreateCandidateForPoll(Guid pollId, Candidate candidate)
        {
            candidate.PollId = pollId;
            candidate.CreatedAt = DateTime.Now;
            candidate.UpdatedAt = DateTime.Now;
            Create(candidate);
        }
    }
}
