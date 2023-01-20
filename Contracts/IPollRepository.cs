using Entities.Models;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePollForUser(Guid userId, Poll poll);

        Task<IEnumerable<Poll>> GetPollsForUserAsync(Guid userId, bool trackChanges);

        Task<Poll> GetPollForUserAsync(Guid userId, Guid id, bool trackChanges);

        Task<IEnumerable<Poll>> GetPollsByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges);

        void DeletePollForUser(Poll poll);
    }
}
