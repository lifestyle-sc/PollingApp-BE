using Contracts;
using Entities.Models;

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
    }
}
