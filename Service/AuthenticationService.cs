using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Service.Contracts;
using Shared.DTOs;
using System.Data;

namespace Service
{
    internal sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationService(ILoggerManager logger, IMapper mapper, IConfiguration configuration, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> RegisterUser(UserForRegistrationDto userForReg)
        {
            var user = _mapper.Map<User>(userForReg);

            var result = await _userManager.CreateAsync(user, userForReg.Password);

            if(result.Succeeded)
                await _userManager.AddToRolesAsync(user, userForReg.Roles);

            return result;
        }
    }
}
