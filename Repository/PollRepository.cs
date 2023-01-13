using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<Poll>> GetPollsForUserAsync(Guid userId, bool trackChanges)
        {
            var polls = await FindByCondition(p => p.UserId == userId.ToString(), trackChanges)
                .OrderBy(p => p.Name)
                .ToListAsync();

            return polls;
        }

        public async Task<Poll> GetPollForUser(Guid userId, Guid id, bool trackChanges)
        {
            var poll = await FindByCondition(p => p.UserId == userId.ToString() && p.Id == id, trackChanges)
                .SingleOrDefaultAsync();

            return poll;
        }
    }
}
