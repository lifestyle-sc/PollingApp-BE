using Contracts;
using Service.Contracts;

namespace Service
{
    internal sealed class PollService : IPollService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public PollService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
