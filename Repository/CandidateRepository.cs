using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

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

#pragma warning disable CS8603 // Possible null reference return.
            return candidate;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<PagedList<Candidate>> GetCandidatesForPollAsync(Guid pollId, CandidateParameters candidateParameters, bool trackChanges)
        {
            var candidates = await FindByCondition(c => c.PollId.Equals(pollId), trackChanges)
            .ToListAsync();

            return PagedList<Candidate>.ToPagedList(candidates, candidateParameters.PageNumber, candidateParameters.PageSize);
        }

        public void DeleteCandidateForPoll(Candidate candidate)
            => Delete(candidate);
            
    }
}
