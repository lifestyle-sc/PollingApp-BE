using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPollService> _pollService;
        private readonly Lazy<ICandidateService> _candidateService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _pollService = new Lazy<IPollService>(() => new PollService(repository, logger));
            _candidateService = new Lazy<ICandidateService>(() => new CandidateService(repository, logger));
        }

        public IPollService PollService => _pollService.Value;

        public ICandidateService CandidateService => _candidateService.Value;
    }
}
