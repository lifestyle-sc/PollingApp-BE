using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository
{
    public class PollRepository : RepositoryBase<Poll>, IPollRepository
    {
        public PollRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePollForUser(Guid userId, Poll poll)
        {
            poll.UserId = userId.ToString();
            poll.CreatedAt = DateTime.Now;
            poll.UpdatedAt = DateTime.Now;
            Create(poll);
        }

        public async Task<PagedList<Poll>> GetPollsForUserAsync(Guid userId, PollParameters pollParameters, bool trackChanges)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var polls = await FindByCondition(p => p.UserId == userId.ToString(), trackChanges)
                .Search(pollParameters.SearchTerm)
                .Sort(pollParameters.OrderBy)
                .ToListAsync();
#pragma warning restore CS8604 // Possible null reference argument.

            return PagedList<Poll>.ToPagedList(polls, pollParameters.PageNumber, pollParameters.PageSize);
        }

        public async Task<Poll> GetPollForUserAsync(Guid userId, Guid id, bool trackChanges)
        {
            var poll = await FindByCondition(p => p.UserId == userId.ToString() && p.Id == id, trackChanges)
                .SingleOrDefaultAsync();

#pragma warning disable CS8603 // Possible null reference return.
            return poll;
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<Poll>> GetPollsByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges)
            => await FindByCondition(p => p.UserId == userId.ToString() && ids.Contains(p.Id), trackChanges)
            .ToListAsync();

        public void DeletePollForUser(Poll poll)
            => Delete(poll);
    }
}
