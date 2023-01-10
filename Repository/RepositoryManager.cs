using Contracts;

namespace Repository
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IPollRepository> _pollRepository;
        private readonly Lazy<ICandidateRepository> _candidateRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _pollRepository = new Lazy<IPollRepository>(() => new PollRepository(_repositoryContext));
            _candidateRepository = new Lazy<ICandidateRepository>(() => new CandidateRepository(_repositoryContext));
        }

        public IPollRepository Poll => _pollRepository.Value;

        public ICandidateRepository Candidate => _candidateRepository.Value;

        public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
    }
}
