using Contracts;
using Entities.Models;

namespace Repository
{
    public class CandidateRepository : RepositoryBase<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {

        }
    }
}
