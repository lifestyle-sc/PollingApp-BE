using Contracts;
using Entities.Models;

namespace Repository
{
    public class PollRepository : RepositoryBase<Poll>, IPollRepository
    {
        public PollRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }

        public void CreatePoll(Guid userId, Poll poll)
        {
            poll.UserId = userId.ToString();
            Create(poll);
        }
    }
}
