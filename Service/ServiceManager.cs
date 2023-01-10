using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPollService> _pollService;
        private readonly Lazy<ICandidateService> _candidateService;
        private readonly Lazy<IAuthenticationService> _authenticationService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _pollService = new Lazy<IPollService>(() => new PollService(repository, logger, mapper, userManager));
            _candidateService = new Lazy<ICandidateService>(() => new CandidateService(repository, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, userManager, roleManager, configuration));
        }

        public IPollService PollService => _pollService.Value;

        public ICandidateService CandidateService => _candidateService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;
    }
}
