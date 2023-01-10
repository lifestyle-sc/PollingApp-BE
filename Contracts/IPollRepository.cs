using Entities.Models;

namespace Contracts
{
    public interface IPollRepository
    {
        void CreatePoll(Guid userId, Poll poll);
    }
}
