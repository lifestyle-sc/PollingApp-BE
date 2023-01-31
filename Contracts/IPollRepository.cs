using Entities.Models;
using Shared.RequestFeatures;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePollForUser(Guid userId, Poll poll);

        Task<PagedList<Poll>> GetPollsForUserAsync(Guid userId, PollParameters pollParameters, bool trackChanges);

        Task<Poll> GetPollForUserAsync(Guid userId, Guid id, bool trackChanges);

        Task<IEnumerable<Poll>> GetPollsByIdsForUserAsync(Guid userId, IEnumerable<Guid> ids, bool trackChanges);

        void DeletePollForUser(Poll poll);
    }
}
