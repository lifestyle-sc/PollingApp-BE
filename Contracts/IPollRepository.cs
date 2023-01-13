using Entities.Models;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePollForUser(Guid userId, Poll poll);

        Task<IEnumerable<Poll>> GetPollsForUserAsync(Guid userId, bool trackChanges);

        Task<Poll> GetPollForUser(Guid userId, Guid id, bool trackChanges);
    }
}
