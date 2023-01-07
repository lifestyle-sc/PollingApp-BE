using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPollService> _pollService;
        private readonly Lazy<ICandidateService> _candidateService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _pollService = new Lazy<IPollService>(() => new PollService(repository, logger, mapper));
            _candidateService = new Lazy<ICandidateService>(() => new CandidateService(repository, logger, mapper));
        }

        public IPollService PollService => _pollService.Value;

        public ICandidateService CandidateService => _candidateService.Value;
    }
}
