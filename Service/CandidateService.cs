using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class CandidateService : ICandidateService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CandidateService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
