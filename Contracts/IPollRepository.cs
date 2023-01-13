using Entities.Models;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePollForUser(Guid userId, Poll poll);

        Task<IEnumerable<Poll>> GetPollsForUser(Guid userId, bool trackChanges);
    }
}
