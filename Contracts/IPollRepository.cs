using Entities.Models;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePollForUser(Guid userId, Poll poll);
    }
}
