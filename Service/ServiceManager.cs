using AutoMapper;
using Contracts;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Service.Contracts;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IPollService> _pollService;
        private readonly Lazy<ICandidateService> _candidateService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IUserService> _userService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IOptions<JwtConfiguration> configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _pollService = new Lazy<IPollService>(() => new PollService(repository, logger, mapper, userManager));
            _candidateService = new Lazy<ICandidateService>(() => new CandidateService(repository, logger, mapper));
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(logger, mapper, configuration, userManager, roleManager));
            _userService = new Lazy<IUserService>(() => new UserService(logger, mapper, configuration, userManager, roleManager));
        }

        public IPollService PollService => _pollService.Value;

        public ICandidateService CandidateService => _candidateService.Value;

        public IAuthenticationService AuthenticationService => _authenticationService.Value;

        public IUserService UserService => _userService.Value;
    }
}
