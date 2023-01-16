using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Candidate> GetCandidateForPollAsync(Guid pollId, Guid id, bool trackChanges)
        {
            var candidate = await FindByCondition(c => c.PollId.Equals(pollId) && c.Id.Equals(id), trackChanges)
                .SingleOrDefaultAsync();

            return candidate;
        }

        public async Task<IEnumerable<Candidate>> GetCandidatesForPollAsync(Guid pollId, bool trackChanges)
            => await FindByCondition(c => c.PollId.Equals(pollId), trackChanges)
            .ToListAsync();
            
    }
}
