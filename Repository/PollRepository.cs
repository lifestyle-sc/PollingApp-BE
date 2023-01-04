using Contracts;
using Entities.Models;

namespace Repository
{
    public class PollRepository : RepositoryBase<Poll>, IPollRepository
    {
        public PollRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
